import { Link } from "react-router-dom"

const Header = () => {
  return (
    <>
        <p>
            <Link to={'/dashboard'}>Listado</Link>
            <Link to={'/student'}><span>Nuevo</span></Link>
            
            <span>Cerrar Sesión</span>
        </p>
    </>
  )
}

export default Header;