// ------------------------------------------------------------
// Copyright (c) Microsoft Corporation.  All rights reserved.
// Licensed under the MIT License (MIT). See License.txt in the repo root for license information.
// ------------------------------------------------------------

#pragma once 

namespace TxnReplicator
{ 
    class TRConfigBase
    {
    public:
        virtual void GetTransactionalReplicatorSettingsStructValues(TRConfigValues & configValues) const = 0;
    };
}
