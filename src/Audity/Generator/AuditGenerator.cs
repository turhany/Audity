using System;
using System.Collections.Generic;
using System.Linq;
using Audity.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Newtonsoft.Json;
// ReSharper disable InvertIf
// ReSharper disable PossibleNullReferenceException
// ReSharper disable ClassNeverInstantiated.Global

namespace Audity.Generator
{
    public class AuditGenerator
    {
        private const string MaskText = "******";

        public static AuditEntryResult Generate(DbContext item, AuditConfigurations configurations)
        {
            var response = new AuditEntryResult();
            if (configurations.IncludeEnvironmentData)
            {
                response.EnvironmentData = new EnvironmentData
                {
                    Version = Environment.Version.ToString(),
                    MachineName = Environment.MachineName,
                    UserName = Environment.UserName,
                    OSVersion = Environment.OSVersion.ToString(),
                    UserDomainName = Environment.UserDomainName
                };
            }
            
            var changes = item.ChangeTracker.Entries()
                .Where(x => 
                    x.State == EntityState.Modified ||
                    x.State == EntityState.Added ||
                    x.State == EntityState.Deleted).ToList();
            
            if (changes.Any())
            {
                foreach (var entityEntry in changes)
                {
                    var auditEntry = new AuditLogEntry();
                    
                    var entityType = entityEntry.Entity.GetType().ToString().Split('.').Last();
                    if (configurations.ExcludeEntities.Contains(entityType))
                    {
                        continue;
                    }
                    
                    var oldValueList = new List<PropertyChangeData>();
                    foreach (var propertyEntry in entityEntry.Metadata.GetProperties())
                    {
                        var property = entityEntry.Property(propertyEntry.Name);
    
                        var oldValueObj = new PropertyChangeData
                        {
                            PropertyName = propertyEntry.Name,
                            OldValue = property.OriginalValue != null ? property.OriginalValue.ToString() : string.Empty,
                            NewValue = property.CurrentValue != null ? property.CurrentValue.ToString() : string.Empty
                        };
                        
                        if (oldValueObj.OldValue != oldValueObj.NewValue)
                        {
                            if (configurations.MaskedEntities.Contains(propertyEntry.Name))
                            {
                                oldValueObj.NewValue = MaskText;
                                oldValueObj.OldValue = MaskText;
                            }
                            oldValueList.Add(oldValueObj);
                        }
                    }

                    auditEntry.KeyPropertyValue = entityEntry.Entity
                        .GetType()
                        .GetProperty(configurations.KeyPropertyName)
                        .GetValue(entityEntry.Entity).ToString();
                    auditEntry.EntityName = entityType;
                    auditEntry.OldValue = JsonConvert.SerializeObject(oldValueList);
                    auditEntry.NewValue = string.Empty;
                    switch (entityEntry.State)
                    {
                        case EntityState.Deleted:
                            auditEntry.AuditLogOperationType = AuditLogOperationType.Deleted;
                            break;
                        case EntityState.Modified:
                            auditEntry.AuditLogOperationType = AuditLogOperationType.Updated;
                            break;
                        case EntityState.Added:
                            auditEntry.AuditLogOperationType = AuditLogOperationType.Added;
                            break;
                    }
                    
                    response.AuditLogEntries.Add(auditEntry);
                }
            }

            return response;
        }
    }
}