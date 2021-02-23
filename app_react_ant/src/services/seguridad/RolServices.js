import http from '../../common/http-common';

 const getAllRoles = () => {
    return http.get("/Seguridad/ListarRoles");
  };
  
  const getRol = id => {
    return http.get(`/Seguridad/ObtenerRol/${id}`);
  };
  
  const addRol = data => {
    return http.post("/Seguridad/AddRol", data);
  };
  
  const updateRol = (data) => {
    return http.put(`/Seguridad/UpdateRol/`, data);
  };
  
  const deleteRol = id => {
    return http.delete(`/Seguridad/DeleteRol/${id}`);
  };

  
  export default {
    getAllRoles,
    getRol,
    addRol,
    updateRol,
    deleteRol
  };