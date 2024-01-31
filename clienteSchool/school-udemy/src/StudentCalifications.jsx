import { useEffect, useState } from "react";
import { useParams } from "react-router-dom";
import * as API from "./services/data";
import Header from "./Header";
import {
  Box,
  TableContainer,
  Table,
  Thead,
  Tbody,
  Tr,
  Th,
  Td,
  Input,
  Center,
  Badge,
} from "@chakra-ui/react";
import { FaCheck, FaTrash } from "react-icons/fa";
import Swal from "sweetalert2";

const StudentCalifications = () => {
  let params = useParams();

  const [calificaciones, setCalificaciones] = useState([]);
  const [calificacion, setCalificacion] = useState([]);

  useEffect(() => {
    API.getCalificaciones(params.matricula).then(setCalificaciones);
  }, [calificaciones]);

  let total = 0;

  calificaciones?.map(
    (calificacion) =>
      (total = total + calificacion.nota * (calificacion.porcentaje / 100))
  );

  function createCalificacion() {
    let matricula = params.matricula;
    let descrField = document.getElementById("descripcion").value;
    let notaField = document.getElementById("nota").value;
    let porcentField = document.getElementById("porcentaje").value;

    let valid =
      descrField.trim() !== "" &&
      notaField.trim() !== "" &&
      porcentField.trim() !== "";

    if (valid) {
      API.createCalificacion(calificacion, matricula).then((result) => {
        if (result == "true") {

          Swal.fire({
            title: "Listo",
            text: "Calificacion añadida",
            icon: "success"
          });
          document.getElementById("descripcion").value = "";
          document.getElementById("nota").value = "";
          document.getElementById("porcentaje").value = "";
          calificaciones.push(calificacion);
          return;
        }
        Swal.fire({
          title: "Error",
          text: "Error al ingresar calificacion",
          icon: "error"
        });

      });
    }
  }

  function deleteCalificacion(id) {
    API.deleteCalificacion(id).then((result) => {
      if (result == "true") {
        Swal.fire({
          title: "Listo",
          text: "Calificacion eliminada",
          icon: "success"
        });
      } else {
        Swal.fire({
          title: "Error",
          text: "Error al eliminar calificación.",
          icon: "error"
        });
      }
    });
  }

  return (
    <>
      <Header />
      <Box m="100px">
        <TableContainer>
          <Table size="md">
            <Thead>
              <Tr>
                <Th>Descripcion</Th>
                <Th>Nota</Th>
                <Th>Ponderacion</Th>
                <Th></Th>
              </Tr>
            </Thead>
            <Tbody>
              {calificaciones?.map((calificacion, index) => (
                <Tr key={index}>
                  <Td>{calificacion.descripcion}</Td>
                  <Td>{calificacion.nota}</Td>
                  <Td>{calificacion.porcentaje} %</Td>
                  <Td>
                    <FaTrash
                      onClick={() => deleteCalificacion(calificacion.id)}
                    />
                  </Td>
                </Tr>
              ))}
              <Tr>
                <Td>
                  <Input
                    type="text"
                    id="descripcion"
                    placeholder="Descripcion"
                    onChange={(event) =>
                      setCalificacion({
                        ...calificacion,
                        descripcion: event.target.value,
                      })
                    }
                  />
                </Td>
                <Td>
                  <Input
                    type="number"
                    id="nota"
                    placeholder="Nota"
                    onChange={(event) =>
                      setCalificacion({
                        ...calificacion,
                        nota: event.target.value,
                      })
                    }
                  />
                </Td>
                <Td>
                  <Input
                    type="number"
                    id="porcentaje"
                    placeholder="Ponderacion"
                    onChange={(event) =>
                      setCalificacion({
                        ...calificacion,
                        porcentaje: event.target.value,
                      })
                    }
                  />
                </Td>
                <Td>
                  <FaCheck
                    cursor="pointer"
                    id="nueva"
                    onClick={() => createCalificacion()}
                  />
                </Td>
              </Tr>
            </Tbody>
          </Table>
        </TableContainer>
        <Center>
          <Box mt="10px" fontSize="lg">
            Nota final:
            <Badge ml='5px' variant="outline" colorScheme="green">
              {total}{" "}
            </Badge>
          </Box>
        </Center>
      </Box>
    </>
  );
};

export default StudentCalifications;
