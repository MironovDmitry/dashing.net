﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace dashing.net.jobs.Properties {
    using System;
    
    
    /// <summary>
    ///   A strongly-typed resource class, for looking up localized strings, etc.
    /// </summary>
    // This class was auto-generated by the StronglyTypedResourceBuilder
    // class via a tool like ResGen or Visual Studio.
    // To add or remove a member, edit your .ResX file then rerun ResGen
    // with the /str option, or rebuild your VS project.
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Resources.Tools.StronglyTypedResourceBuilder", "4.0.0.0")]
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    internal class Resources {
        
        private static global::System.Resources.ResourceManager resourceMan;
        
        private static global::System.Globalization.CultureInfo resourceCulture;
        
        [global::System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal Resources() {
        }
        
        /// <summary>
        ///   Returns the cached ResourceManager instance used by this class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Resources.ResourceManager ResourceManager {
            get {
                if (object.ReferenceEquals(resourceMan, null)) {
                    global::System.Resources.ResourceManager temp = new global::System.Resources.ResourceManager("dashing.net.jobs.Properties.Resources", typeof(Resources).Assembly);
                    resourceMan = temp;
                }
                return resourceMan;
            }
        }
        
        /// <summary>
        ///   Overrides the current thread's CurrentUICulture property for all
        ///   resource lookups using this strongly typed resource class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Globalization.CultureInfo Culture {
            get {
                return resourceCulture;
            }
            set {
                resourceCulture = value;
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to select count(wo.WORKORDERID) &apos;breachedWorkordersCount&apos;	
        ///from workorder wo
        ///	left join workorderstates ws on ws.WORKORDERID = wo.WORKORDERID	
        ///where ws.STATUSID &lt;&gt; 3
        ///	and ((ws.CATEGORYID &lt;&gt; 1803 
        ///		or ws.CATEGORYID is null)
        ///		and (ws.REQUESTTYPEID &lt;&gt; 1201))
        ///	and ws.ISOVERDUE = 1	.
        /// </summary>
        internal static string breachedWOsCount_sql {
            get {
                return ResourceManager.GetString("breachedWOsCount_sql", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to select count(wo.WORKORDERID) &apos;soonBreachedWorkordersCount&apos;		
        ///from workorder wo
        ///	left join workorderstates ws on ws.WORKORDERID = wo.WORKORDERID	
        ///where ws.STATUSID &lt;&gt; 3
        ///	and ((ws.CATEGORYID &lt;&gt; 1803 
        ///		or ws.CATEGORYID is null)
        ///		and (ws.REQUESTTYPEID &lt;&gt; 1201))
        ///	and ws.ISOVERDUE = 0	
        ///	and ((time_to_sec(timediff(from_unixtime(wo.DUEBYTIME/1000),now())) / 60) &lt;= 60
        ///		and (time_to_sec(timediff(from_unixtime(wo.DUEBYTIME/1000),now())) / 60) &gt;=0).
        /// </summary>
        internal static string sooBreachedWOsCount_sql {
            get {
                return ResourceManager.GetString("sooBreachedWOsCount_sql", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to select wo.WORKORDERID
        ///	,wo.TITLE
        ///	,sd.NAME &apos;ServiceName&apos;
        ///	,ti.FIRST_NAME &apos;Technician&apos;		
        ///	,DATEDIFF(Now(),FROM_UNIXTIME(wo.DUEBYTIME/1000)) &apos;delay&apos;
        ///	
        ///from workorder wo
        ///	left join workorderstates ws on ws.WORKORDERID = wo.WORKORDERID
        ///	left join servicedefinition sd on sd.SERVICEID = wo.SERVICEID
        ///	LEFT JOIN SDUser sdu ON sdu.USERID = ws.OWNERID
        ///	LEFT JOIN AaaUser ti ON sdu.USERID=ti.USER_ID
        ///where ws.STATUSID &lt;&gt; 3
        ///	and ((ws.CATEGORYID &lt;&gt; 1803 
        ///		or ws.CATEGORYID is null)
        ///		and (ws.REQUESTTYPEID &lt;&gt; [rest of string was truncated]&quot;;.
        /// </summary>
        internal static string Top5BreachedRequests_sql {
            get {
                return ResourceManager.GetString("Top5BreachedRequests_sql", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to select wo.WORKORDERID
        ///	,wo.TITLE
        ///	,sd.NAME &apos;ServiceName&apos;
        ///	,ti.FIRST_NAME &apos;Technician&apos;		
        ///	,(time_to_sec(timediff(from_unixtime(wo.DUEBYTIME/1000),now())) / 60) &apos;minutesLeft&apos;
        ///	
        ///from workorder wo
        ///	left join workorderstates ws on ws.WORKORDERID = wo.WORKORDERID
        ///	left join servicedefinition sd on sd.SERVICEID = wo.SERVICEID
        ///	LEFT JOIN SDUser sdu ON sdu.USERID = ws.OWNERID
        ///	LEFT JOIN AaaUser ti ON sdu.USERID=ti.USER_ID
        ///where ws.STATUSID &lt;&gt; 3
        ///	and ((ws.CATEGORYID &lt;&gt; 1803 
        ///		or ws.CATEGORYID is null)
        /// [rest of string was truncated]&quot;;.
        /// </summary>
        internal static string Top5SoonBreachedRequests_sql {
            get {
                return ResourceManager.GetString("Top5SoonBreachedRequests_sql", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to select count(wo.WORKORDERID) as totalRequests
        ///from workorder wo
        ///	left join workorderstates ws on ws.WORKORDERID = wo.WORKORDERID
        ///where (ws.CATEGORYID &lt;&gt; 1803 
        ///	or ws.CATEGORYID is null)
        ///	and (ws.REQUESTTYPEID &lt;&gt; 1201).
        /// </summary>
        internal static string WOsCount_sql {
            get {
                return ResourceManager.GetString("WOsCount_sql", resourceCulture);
            }
        }
    }
}
