import { useParams } from "react-router-dom";
import Header from "./Header";
import { useEffect, useState } from "react";
import * as API from "./services/data";
import {
  Center,
  Box,
  FormControl,
  FormLabel,
  Input,
} from "@chakra-ui/react";
import Swal from "sweetalert2";

const StudentEdit = () => {
  let params = useParams();
  const [student, setStudent] = useState({
    dni: "",
    nombre: "",
    direccion: "",
    edad: "",
    email: "",
  });

  useEffect(() => {
    API.getStudentDetails(params.studentId).then(setStudent);
  }, []);

  function handleSubmit(e) {
    e.preventDefault();
    API.editStudent(student).then((retsult) => {
      if (retsult == "true") {
        Swal.fire({
          title: "Error",
          text: "Error al modificar Alumno",
          icon: "error"
        });

        return;
      }
      Swal.fire({
        title: "Error",
        text: "Error al modificar Alumno",
        icon: "error"
      });

    });
  }

  return (
    <>
      <Header />
      <Center>
        <Box m="40px" boxShadow="xl" borderRadius="md" width="40%" id="caja">
          <Box textAlign="center">Editar Estudiante</Box>
          <Box p='20px'>
            <form action="" id="formaulario" onSubmit={handleSubmit}>
            <FormControl>
                <FormLabel>DNI</FormLabel>
                <Input
                  type="text"
                  id="dni"
                  required
                  value={student.dni}
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
                  value={student.nombre}
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
                  value={student.direccion}
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
                  value={student.edad}
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
                  value={student.email}
                  required
                  onChange={(event) =>
                    setStudent({ ...student, email: event.target.value })
                  }
                />
              </FormControl>
              <br />
              <Input
                type="submit"
                mt="3px"
                id="editar"
                borderColor="teal"
                value="Editar"
              />
            </form>
          </Box>
        </Box>
      </Center>
    </>
  );
};

export default StudentEdit;
