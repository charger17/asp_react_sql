import { useState } from "react";
import * as API from "./services/data";
import imagen from "./assets/login-icon.png";
import { useNavigate } from "react-router-dom";
import {
  Box,
  Heading,
  FormControl,
  FormLabel,
  Input,
  Center,
  Image
} from "@chakra-ui/react";

import Swal from "sweetalert2"

const Login = () => {
  const [teacher, setTeacher] = useState({ usuario: "", passsword: "" });
  const navigate = useNavigate();

  async function handleSubmit(e) {
    e.preventDefault();
    const response = await API.login(teacher.usuario, teacher.passsword);

    if (response.length != 0) {
      sessionStorage.setItem("usuario", response);
      navigate("/dashboard");
    } else {
      Swal.fire({
        title: "Error",
        text: "Error al realizar el login",
        icon: "error"
      });
    }
  }
  return (
    <>
      <Center>
        <Image mt='3px' src={imagen} width='150px' height='150px'/>
      </Center>
      <Center>
        <Box m="2%" boxShadow="xl" borderRadius="md" width="40%" id="caja">
          <Box>
            <Heading textAlign="center">Iniciar Sesion</Heading>
          </Box>
          <Box p="20px">
            <form action="" id="formulario" onSubmit={handleSubmit}>
              <FormControl mt="3">
                <FormLabel>Usuario</FormLabel>
                <Input
                  required
                  type="text"
                  id="usuario"
                  onChange={(event) =>
                    setTeacher({ ...teacher, usuario: event.target.value })
                  }
                />
              </FormControl>
              <br />
              <FormControl mt="3">
                <FormLabel>Password</FormLabel>
                <Input
                  required
                  type="password"
                  id="pass"
                  onChange={(event) =>
                    setTeacher({ ...teacher, passsword: event.target.value })
                  }
                />
                <br />
              </FormControl>
              <FormControl mt="3">
                <Input
                  type="submit"
                  mt="3px"
                  id="enviar"
                  borderColor="teal"
                  value="Login"
                />
              </FormControl>
            </form>
          </Box>
        </Box>
      </Center>
    </>
  );
};

export default Login;
