// ------------------------------------------------------------
// Copyright (c) Microsoft Corporation.  All rights reserved.
// Licensed under the MIT License (MIT). See License.txt in the repo root for license information.
// ------------------------------------------------------------

// CS1591 - Missing XML comment for publicly visible type or member 'Type_or_Member' is disabled in this file because it does not ship anymore.
#pragma warning disable 1591

namespace System.Fabric.Testability.Client.Requests
{
    using System;
    using System.Fabric.Interop;
    using System.Fabric.Testability.Common;
    using System.Globalization;
    using System.Threading;
    using System.Threading.Tasks;

    public class DeleteNameRequest : FabricRequest
    {
        public DeleteNameRequest(IFabricClient fabricClient, Uri name, TimeSpan timeout)
            : base(fabricClient, timeout)
        {
            ThrowIf.Null(name, "name");

            this.Name = name;
            this.ConfigureErrorCodes();
        }

        public Uri Name
        {
            get;
            private set;
        }

        public override string ToString()
        {
            return string.Format(CultureInfo.InvariantCulture, "Delete name {0} with timeout {1}", this.Name, this.Timeout);
        }

        public override async Task PerformCoreAsync(CancellationToken cancellationToken)
        {
            this.OperationResult = await this.FabricClient.DeleteNameAsync(this.Name, this.Timeout, cancellationToken);
        }

        private void ConfigureErrorCodes()
        {
            this.SucceedErrorCodes.Add((uint)NativeTypes.FABRIC_ERROR_CODE.FABRIC_E_NAME_DOES_NOT_EXIST);
        }
    }
}


#pragma warning restore 1591