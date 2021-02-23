import React,{ useEffect, useState } from 'react';
import { RolServices, PermisosServices } from '../../services/index';

const RolesPage = () => {

    const [roles, setRoles] = useState([]);
    
    useEffect(() => {
        cargarRoles();
     }, []);

    const cargarRoles = () => {
        RolServices.getAllRoles()
        .then(response => {
             setRoles(response.data);         
             console.log(response) 
        }).catch(e => { console.log(e); });

        PermisosServices.getAllPermisos()
        .then(response => {
             setRoles(response.data);         
             console.log(response) 
        }).catch(e => { console.log(e); });
    }

    return(
 
        
        <div>Roles pagina</div>
    )
}


export default RolesPage;