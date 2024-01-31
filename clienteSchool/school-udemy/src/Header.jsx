import { Link } from "react-router-dom"
import {useNavigate} from "react-router-dom";

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
        <p>
            <Link to={'/dashboard'}>Listado</Link>
            <Link to={'/student'}><span>Nuevo</span></Link>
            
            <span onClick={() => cerrarSesion()}>Cerrar Sesión</span>
        </p>
    </>
  )
}

export default Header;