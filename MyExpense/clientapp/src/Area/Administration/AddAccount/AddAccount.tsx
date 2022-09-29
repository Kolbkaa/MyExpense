import React, { useRef, useState } from 'react'
import { Toast } from 'primereact/toast';
import { InputText } from 'primereact/inputtext';
import { Button } from 'primereact/button';
import { AccountClient, CreateAccountCommand, ValidationFailure } from '../../../web-api-client';
import { ShowAccountPath } from '../../../Shared/RouterPath';

const AddAccount = () => {
    const toast = useRef<Toast>(null);
    const [value, setValue] = useState('');

    const AddAccountRequest = (name: string) => {
        new AccountClient()
            .createAccount(new CreateAccountCommand({ name }))
            .then(() => {
                toast.current?.show({ life: 5000, severity: 'success', summary: 'Sukces', detail: 'Dodano konto' });
                window.location.href = ShowAccountPath;
            })
            .catch(errors => Array.from(errors).map(x => toast.current?.show({ life: 5000, severity: 'error', summary: 'Błąd', detail: ValidationFailure.fromJS(x).errorMessage })))
    }

    return <>
        <Toast ref={toast} />
        <div className="formgroup-inline">
            <div className="field">
                <label htmlFor="accountName">Nazwa konta</label>
                <InputText value={value} onChange={(e) => setValue(e.target.value)} id="accountName" type="text" />
            </div>
            <Button label="Save" onClick={() => AddAccountRequest(value)} />
        </div>
    </>

}



export default AddAccount;

