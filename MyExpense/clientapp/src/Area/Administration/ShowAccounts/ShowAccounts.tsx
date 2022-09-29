
import React, { useState, useEffect } from 'react';
import { DataTable } from 'primereact/datatable';
import { Column } from 'primereact/column';
import { AccountClient, AccountDto } from '../../../web-api-client';

const ShowAccount = () => {
    const [accounts, setAccounts] = useState(Array<AccountDto>);
    const productService = new AccountClient();

    useEffect(() => {
        productService.getAccounts().then(accounts => setAccounts(accounts));
    }, []);
    return (
        <div>
            <div className="card">
                <DataTable value={accounts} responsiveLayout="scroll">
                    <Column field="name" header="Name"></Column>
                </DataTable>
            </div>
        </div>
    );
}
export default ShowAccount;