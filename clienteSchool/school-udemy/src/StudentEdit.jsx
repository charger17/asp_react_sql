import { useParams } from "react-router-dom";
import Header from "./Header";
import { useEffect, useState } from "react";
import * as API from "./services/data";

const StudentEdit = () => {
  let params = useParams();
  const [student, setStudent] = useState({
    dni: "",
    nombre: "",
    direccion: "",
    edad: "",
    email: ""
  });

  useEffect(() => {
    API.getStudentDetails(params.studentId).then(setStudent);
  },[]);

  function handleSubmit(e){
    e.preventDefault();
    API.editStudent(student).then(retsult => {
        if (retsult == "true") {
            alert("Alumno Modificado");
            return;
        }
        alert("Error al modificar Alumno");

    })
  }

  return (
    <>
      <Header />
      <form action="" id="formaulario" onSubmit={handleSubmit}>
        DNI:{" "}
        <input
          type="text"
          id="dni"
          required
          value={student.dni}
          onChange={(event) =>
            setStudent({ ...student, dni: event.target.value })
          }
        />{" "}
        <br />
        Nombre:{" "}
        <input
          type="text"
          id="nombre"
          required
          value={student.nombre}
          onChange={(event) =>
            setStudent({ ...student, nombre: event.target.value })
          }
        />{" "}
        <br />
        Direccion:{" "}
        <input
          type="text"
          id="direccion"
          required
          value={student.direccion}
          onChange={(event) =>
            setStudent({ ...student, direccion: event.target.value })
          }
        />{" "}
        <br />
        Edad:{" "}
        <input
          type="number"
          id="edad"
          required
          value={student.edad}
          onChange={(event) =>
            setStudent({ ...student, edad: event.target.value })
          }
        />{" "}
        <br />
        Email:{" "}
        <input
          type="email"
          id="email"
          required
          value={student.email}
          onChange={(event) =>
            setStudent({ ...student, email: event.target.value })
          }
        />{" "}
        <br />
        <input type="submit" value="Editar" id='editar' />
      </form>
    </>
  );
};

export default StudentEdit;
