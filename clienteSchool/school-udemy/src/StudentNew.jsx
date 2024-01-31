import { useState } from "react";
import Header from "./Header";
import * as API from "./services/data";

const StudentNew = () => {
  const [student, setStudent] = useState({
    dni: "",
    nombre: "",
    direccion: "",
    edad: "",
    email: "",
    asignatura: "1",
  });

  function handleSubmit(e) {
    e.preventDefault();
    API.createStudent(student).then((result) => {
      if (result == "true") {
        alert("Alumno insertado");
        document.getElementById("formulario").reset;
        return;
      }
      console.log(result);
      alert("Error al insertar el alumno");
      document.getElementById("formulario").reset;
    });
  }

  return (
    <>
      <Header />
      <p>Nuevo estudiante</p>
      <form action="" id="formulario" onSubmit={handleSubmit}>
        DNI:{" "}
        <input
          type="text"
          id="dni"
          required
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
          onChange={(event) =>
            setStudent({ ...student, email: event.target.value })
          }
        />{" "}
        <br />
        Asignatura:{" "}
        <select
          id="asignatura"
          required
          onChange={event => {
            console.log('Nuevo valor de asignatura:', event.target.value);
            setStudent({ ...student, asignatura: event.target.value });
          }}
        >
          <option value="1">Matematicas</option>
          <option value="2">Informática</option>
          <option value="3">Inglés</option>
          <option value="4">Lengua</option>
        </select>
        <br />
        <input type="submit" value="Nuevo" />
      </form>
    </>
  );
};

export default StudentNew;
