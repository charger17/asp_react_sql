import { useEffect, useState } from "react"
import * as API from './services/data'
const StudentList = () => {
  let usuario = sessionStorage.getItem("usuario");
  const [students, setStudents]= useState([]);

  useEffect(()=>{
     API.getStudents(usuario).then(setStudents);
  }, [usuario]);

  function deleteStudent(id){
    API.deleteStudent(id).then(result => {
      if (result == "true") {
        alert("Estudiante eliminado con exito");
        return;
      }
      alert("Error al eliminar el alumno");
    })
  }

  return (
    <>
        <table>
          <thead>
            <tr>
            <th>ID</th>
            <th>DNI</th>
            <th>Nombre</th>
            <th>Direccion</th>
            <th>Edad</th>
            <th>Email</th>
            <th>Asignatura</th>
            <th></th>
            <th></th>
            <th></th>
            </tr>
          </thead>
          <tbody>
            {
              students?.map(student => (
                <tr key={student.id}>
                  <td>{student.id}</td>                  
                  <td>{student.dni}</td>                  
                  <td>{student.nombre}</td>                  
                  <td>{student.direccion}</td>                  
                  <td>{student.edad}</td>                  
                  <td>{student.email}</td>                  
                  <td>{student.asignatura}</td>
                  <td>Editar</td>
                  <td>Calificar</td>
                  <td onClick={() => deleteStudent(student.id)}>Eliminar</td>                  
                </tr>
              ))
            }
          </tbody>
        </table>
    </>
  )
}

export default StudentList