import { useEffect, useState } from "react";
import * as API from "./services/data";
import { Link } from "react-router-dom";
import { Box, TableContainer, Table, Thead, Tr, Th, Tbody, Td } from "@chakra-ui/react";
import { FaEdit, FaStickyNote, FaTrash } from 'react-icons/fa';
import Swal from "sweetalert2";
const StudentList = () => {
  let usuario = sessionStorage.getItem("usuario");
  const [students, setStudents] = useState([]);
  console.log(students);

  useEffect(() => {
    API.getStudents(usuario).then(setStudents);
  }, []);

  function deleteStudent(id) {
    API.deleteStudent(id).then((result) => {
      if (result == "true") {
        Swal.fire({
          title: "Listo",
          text: "Estudiante eliminado con exito",
          icon: "success"
        });

        return;
      }
      Swal.fire({
        title: "Error",
        text: "Error al eliminar el alumno",
        icon: "error"
      });

    });
  }

  return (
    <>
      <Box m="50px">
        <TableContainer>
          <Table size='md' variant='striped' colorSchema="gray">
            <Thead>
              <Tr>
                <Th>ID</Th>
                <Th>DNI</Th>
                <Th>Nombre</Th>
                <Th>Direccion</Th>
                <Th>Edad</Th>
                <Th>Email</Th>
                <Th>Asignatura</Th>
                <Th></Th>
                <Th></Th>
                <Th></Th>
              </Tr>
            </Thead>
            <Tbody>
              {students?.map((student) => (
                <Tr key={student.id}>
                  <Td>{student.id}</Td>
                  <Td>{student.dni}</Td>
                  <Td>{student.nombre}</Td>
                  <Td>{student.direccion}</Td>
                  <Td>{student.edad}</Td>
                  <Td>{student.email}</Td>
                  <Td>{student.asignatura}</Td>
                  <Td>
                    <Link to={"/student/" + student.id}><FaEdit/></Link>
                  </Td>
                  <Td>
                    <Link to={"/student/califications/" + student.matriculaId}>
                      <FaStickyNote/>
                    </Link>
                  </Td>
                  <Td onClick={() => deleteStudent(student.id)} cursor='pointer'><FaTrash/></Td>
                </Tr>
              ))}
            </Tbody>
          </Table>
        </TableContainer>
      </Box>
    </>
  );
};

export default StudentList;
