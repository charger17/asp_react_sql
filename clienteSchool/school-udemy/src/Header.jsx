import { Link } from "react-router-dom"
import {useNavigate} from "react-router-dom";
import {
  Flex,
  HStack,
  Box
} from "@chakra-ui/react";

const Header = () => {
  const navigate = useNavigate();
  function cerrarSesion(){
    sessionStorage.removeItem('usuario');
    navigate("/");
  }

  if (!sessionStorage.getItem('usuario')) {
    navigate("/");
    return;
  }

  return (
    <>
        <Flex width='100%' h='70px' p='6px' align='center' justify='space-between' bgColor='#2B6CB0' color='white'>
          <HStack as='nav' spacing='10px'>
            <Link to={'/dashboard'}><Box _hover={{color: "gray.300"}}>Listado</Box></Link>
            <Link to={'/student'}><Box _hover={{color: "gray.300"}}>Nuevo</Box></Link>
          </HStack>
          <HStack>
            <Box mr='20px' cursor='pointer' _hover={{color: "gray"}} onClick={() => cerrarSesion()}>Cerrar Sesión</Box>
          </HStack>
        </Flex>
    </>
  )
}

export default Header;