import { useState } from "react";
import Header from "./Header";
import * as API from "./services/data";
import {
  Center,
  Box,
  FormControl,
  FormLabel,
  Input,
  Select,
} from "@chakra-ui/react";
import Swal from "sweetalert2";

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
        Swal.fire({
          title: "Listo",
          text: "Alumno insertado",
          icon: "success"
        });

        document.getElementById("formulario").reset;
        return;
      }
      Swal.fire({
          title: "Error",
          text: "Error al insertar el alumno",
          icon: "error"
        });

      document.getElementById("formulario").reset;
    });
  }

  return (
    <>
      <Header />
      <Center>
        <Box m="40px" boxShadow="xl" borderRadius="md" width="40%" id="caja">
          <Box textAlign="center">Nuevo Estudiante</Box>
          <Box p="20px">
            <form action="" id="formulario" onSubmit={handleSubmit}>
              <FormControl>
                <FormLabel>DNI</FormLabel>
                <Input
                  type="text"
                  id="dni"
                  required
                  onChange={(event) =>
                    setStudent({ ...student, dni: event.target.value })
                  }
                />
              </FormControl>
              <br />
              <FormControl>
                <FormLabel>Nombre</FormLabel>
                <Input
                  type="text"
                  id="nombre"
                  required
                  onChange={(event) =>
                    setStudent({ ...student, nombre: event.target.value })
                  }
                />
              </FormControl>
              <br />
              <FormControl>
                <FormLabel>Direccion</FormLabel>
                <Input
                  type="text"
                  id="direccion"
                  required
                  onChange={(event) =>
                    setStudent({ ...student, direccion: event.target.value })
                  }
                />
              </FormControl>
              <br />
              <FormControl>
                <FormLabel>Edad</FormLabel>
                <Input
                  type="number"
                  id="edad"
                  required
                  onChange={(event) =>
                    setStudent({ ...student, edad: event.target.value })
                  }
                />
              </FormControl>
              <br />
              <FormControl>
                <FormLabel>Email</FormLabel>
                <Input
                  type="email"
                  id="email"
                  required
                  onChange={(event) =>
                    setStudent({ ...student, email: event.target.value })
                  }
                />
              </FormControl>
              <br />
              <FormControl>
                <FormLabel>Asignatura</FormLabel>
                <Select
                  id="asignatura"
                  required
                  onChange={(event) => {
                    console.log(
                      "Nuevo valor de asignatura:",
                      event.target.value
                    );
                    setStudent({ ...student, asignatura: event.target.value });
                  }}
                >
                  <option value="1">Matematicas</option>
                  <option value="2">Informática</option>
                  <option value="3">Inglés</option>
                  <option value="4">Lengua</option>
                </Select>
              </FormControl>

              <br />
              <Input
                type="submit"
                mt="3px"
                id="nuevo"
                borderColor="teal"
                value="Nuevo"
              />
            </form>
          </Box>
        </Box>
      </Center>
    </>
  );
};

export default StudentNew;
