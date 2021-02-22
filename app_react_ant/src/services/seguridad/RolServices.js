import http from '../../common/http-common';

const getAllRoles = () => {
    return http.get("/tutorials");
  };
  
  const get = id => {
    return http.get(`/tutorials/${id}`);
  };
  
  const addRol = data => {
    return http.post("/tutorials", data);
  };
  
  const updateRol = (id, data) => {
    return http.put(`/tutorials/${id}`, data);
  };
  
  const deleteRol = id => {
    return http.delete(`/tutorials/${id}`);
  };

  
  export default {
    getAllRoles,
    get,
    addRol,
    updateRol,
    deleteRol
  };