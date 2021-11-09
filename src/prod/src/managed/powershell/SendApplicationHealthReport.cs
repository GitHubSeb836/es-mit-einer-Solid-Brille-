// ------------------------------------------------------------
// Copyright (c) Microsoft Corporation.  All rights reserved.
// Licensed under the MIT License (MIT). See License.txt in the repo root for license information.
// ------------------------------------------------------------

namespace Microsoft.ServiceFabric.Powershell
{
    using System;
    using System.Fabric.Health;
    using System.Management.Automation;

    /// <summary>
    /// This class will implement "Send-ApplicationHealthReport" cmdlet.
    /// Required parameters: ApplicationName, HeathStatus, SourceId, Property,
    /// Optional parameters: Description, TimeToLive, RemoveWhenExpired
    /// </summary>
    [Cmdlet(VerbsCommunications.Send, "ServiceFabricApplicationHealthReport")]
    public sealed class SendApplicationHealthReport : SendHealthReport
    {
        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, Position = 0,
                   HelpMessage = "Name of the concerned application. e.g. fabric:/myapps/calc")]
        [ValidateNotNullOrEmpty]
        public Uri ApplicationName
        {
            get;
            set;
        }

        /// errorId for the executing cmdlet. Any exception will be reported with this errorId
        protected override string SendHealthReportErrorId
        {
            get
            {
                return Constants.SendApplicationHealthReportErrorId;
            }
        }

        protected override HealthReport GetHealthReport(HealthInformation healthInformation)
        {
            return new ApplicationHealthReport(this.ApplicationName, healthInformation);
        }
    }
}