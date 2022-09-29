import { Card } from 'primereact/card';
import React, { useState } from 'react';
import {
    BrowserRouter as Router,
    Routes,
    Route,
} from 'react-router-dom';
import './App.css';
import AddAccount from './Area/Administration/AddAccount/AddAccount';
import ShowAccount from './Area/Administration/ShowAccounts/ShowAccounts';
import Menu from './Menu/Menu';
import { AddAccountPath, ShowAccountPath } from './Shared/RouterPath';

function App() {
    return <><Menu />
    <Card>
        <Routes>
            <Route path={ShowAccountPath} element={< ShowAccount />}></Route>
            <Route path={AddAccountPath} element={< AddAccount />}></Route>
        </Routes>
        </Card>
    </>
}

export default App;