![alt tag](/img/audity.png)  

Simple EF(Core) Change Tracker base audit log library.

[![NuGet version](https://badge.fury.io/nu/Audity.svg)](https://badge.fury.io/nu/Audity)  ![Nuget](https://img.shields.io/nuget/dt/Audity) 

#### Features:
- Give entity key property value as your configuration (KeyPropertyName)
- Can get Environment data (IncludeEnvironmentData)
    - Version
    - MachineName
    - UserName
    - OSVersion
    - UserDomainName
- Get Audit data for changed entities (AuditLogEntries)
    - KeyPropertyValue
    - EntityName
    - OldValue
    - NewValue
    - AuditLogOperationType
        - Added
        - Updated
        - Deleted
- Can exclude Entities from Audit flow (ExcludeEntities)
- Can mask Properties from Audit flow (MaskedProperties, masked with "******")
- Can exclude property from generated log data (AudityIgnore attribute)

#### Atention:
- If you get data with "AsNoTracking()", you can not get property change data  
     
##### Audit Data Configuration Object Structure:

```cs

    public class AuditConfiguration
    {
        public string KeyPropertyName { get; set; }
        public bool IncludeEnvironmentData { get; set; }
        public List<string> ExcludeEntities { get; set; } = new List<string>();
        public List<string> MaskedProperties { get; set; } = new List<string>();
    }

```

##### Audit Data Response Object Structure:

```cs

    public class AuditEntryResult
    {
        public EnvironmentData EnvironmentData { get; set; }
        public List<AuditLogEntry> AuditLogEntries { get; set; } = new List<AuditLogEntry>();
    }

    public class EnvironmentData
    {
        public string MachineName { get; set; }
        public string OSVersion { get; set; }
        public string UserDomainName { get; set; }
        public string UserName { get; set; }
        public string Version { get; set; }
    }

    public class AuditLogEntry
    {
        public string KeyPropertyValue { get; set; }
        public string EntityName { get; set; }
        public AuditLogOperationType AuditLogOperationType { get; set; }
        public string OldValue { get; set; }
        public string NewValue { get; set; }
    }
    
    public enum AuditLogOperationType
    {
        Added = 1,
        Updated = 2,
        Deleted = 3
    }

```

##### Usage(Code):

```cs

    var auditResponse =_context.ChangeTracker.GetAuditData(new AuditConfiguration
    {
        KeyPropertyName = "Id",
        IncludeEnvironmentData = true,
        MaskedProperties = new List<String>(){ "Password" }
    });
    
```
   
![alt tag](/img/sample.png) 

### Release Notes

##### 1.0.15
* ContractResolver added for AudityIgnore.

##### 1.0.14
* AudityIgnore attribute read, write data set as false.

##### 1.0.13
* AudityIgnore attribute added.

##### 1.0.12
* JsonSeralizer settings serialize bug fixed.

##### 1.0.11
* IPAddress serialize bug fixed.

##### 1.0.10
* "KeyPropertyValue" select null refernce bug fixed

##### 1.0.9
* Ef Version updated to  7.0.9

##### 1.0.8
* Newtonsoft SerializeObject reference loop options changed

##### 1.0.7
* Ef Version updated to  7.0.5
* Newtonsoft.Json Version updated to  13.0.3
* Newtonsoft SerializeObject reference loop bug fixed


##### 1.0.6
* Ef Version updated to  7.0.1
* Newtonsoft.Json Version updated to  13.0.2

##### 1.0.5
* Ef Version updated to  6.0.8

##### 1.0.4
* Target Framework changed as net6.0
* Ef Version updated to  6.0.1

##### 1.0.3
* MaskedEntities name changed as MaskedProperties
* NewValue data not mask bug fixed

##### 1.0.2
* GetAuditData extension moved under ChangeTracker
* AuditConfigurations name changed to AuditConfiguration
* Null check added for ChangeTracker and AuditConfiguration
* AuditLogEntry.NewValue null bug fixed

##### 1.0.1
* GetAuditData extension moved under ChangeTracker

##### 1.0.0
* Base release
* Support Ef Core 5.0.12
