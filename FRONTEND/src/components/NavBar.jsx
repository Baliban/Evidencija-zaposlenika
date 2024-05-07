import Container from 'react-bootstrap/Container';
import Nav from 'react-bootstrap/Nav';
import Navbar from 'react-bootstrap/Navbar';
import NavDropdown from 'react-bootstrap/NavDropdown';
import { RoutesNames } from '../constants';
import { useNavigate } from 'react-router-dom';


export default function NavBar(){

    const navigate = useNavigate();

    return(
        <>
            <Navbar collapseOnSelect expand="lg" className="bg-body-tertiary">
            <Container>
                <Navbar.Brand 
                className='kursor'
                onClick={()=>navigate(RoutesNames.HOME)}
                >WEB Aplikacija</Navbar.Brand>
                <Navbar.Toggle aria-controls="responsive-navbar-nav" />
                <Navbar.Collapse id="responsive-navbar-nav">
                <Nav className="me-auto">
                    <Nav.Link 
                    href="http://mrb.tryasp.net/swagger/index.html"
                    target='_blank'>SWAGGER</Nav.Link>
                    
                    <NavDropdown title="Navigacija" id="collapsible-nav-dropdown">
                    <NavDropdown.Item 
                    onClick={()=>navigate(RoutesNames.RASPOREDI_PREGLED)}>
                    Raspored</NavDropdown.Item>
                    <NavDropdown.Item onClick={()=>navigate(RoutesNames.DJELATNICI_PREGLED)}>
                       Djelatnici
                    </NavDropdown.Item>
                    <NavDropdown.Item onClick={()=>navigate(RoutesNames.ODJELI_PREGLED)}>
                       Odjeli
                    </NavDropdown.Item>
                    
                    </NavDropdown>
                </Nav>
                
                </Navbar.Collapse>
            </Container>
        </Navbar>
        </>
    );
}