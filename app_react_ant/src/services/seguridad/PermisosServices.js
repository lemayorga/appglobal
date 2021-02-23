import http from '../../common/http-common';

 const getAllPermisos = () => {
    return http.get("/Seguridad/ListarPermisos");
  };
  
  const getPermiso = id => {
    return http.get(`/Seguridad/ObtenerPermiso/${id}`);
  };
  
  const addPermiso = data => {
    return http.post("/Seguridad/AddPermiso", data);
  };
  
  const updatePermiso = (data) => {
    return http.put(`/Seguridad/UpdateRol/`, data);
  };
  
  const deletePermiso = id => {
    return http.delete(`/Seguridad/DeletePermiso/${id}`);
  };

  
  export default {
    getAllPermisos,
    getPermiso,
    addPermiso,
    updatePermiso,
    deletePermiso
  };