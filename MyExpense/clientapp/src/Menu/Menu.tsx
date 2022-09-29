import React from 'react';
import { MegaMenu } from 'primereact/megamenu';
import { AddAccountPath, ShowAccountPath } from '../Shared/RouterPath';

const Menu = () => {
    const items = [
        {
            label: 'Administracja', icon: 'pi pi-fw pi-cog',
            items: [
                [
                    {
                        label: 'Konta',
                        items: [{
                            label: 'Wyświelt', command: () => {
                                window.location.href = ShowAccountPath;
                            }
                        }, {
                            label: 'Dodaj', command: () => {
                                window.location.href = AddAccountPath;
                            }
                        }]
                    }
                ]
            ]
        },

    ]
    return (
        <MegaMenu model={items} />);
}
export default Menu;