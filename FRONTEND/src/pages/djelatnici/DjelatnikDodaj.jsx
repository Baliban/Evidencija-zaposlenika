import { Button, Col, Container, Form, Row } from "react-bootstrap";
import { Link, useNavigate } from "react-router-dom";
import { RoutesNames } from "../../constants";
import DjelatniciService from "../../services/DjelatniciService";



export default function DjelatnikDodaj(){
    const navigate = useNavigate();

    async function dodaj(djelatnici){
        const odgovor = await DjelatniciService.post(djelatnici);
        if (odgovor.greska){
            console.log(odgovor.poruka);
            alert('Pogledaj konzolu');
            return;
        }
        navigate(RoutesNames.DJELATNICI_PREGLED);
    }

    function obradiSubmit(e){ 
        e.preventDefault();
        

        const podaci = new FormData(e.target);

        const djelatnici = {
            
            prezime: podaci.get('prezime'), 
            ime: podaci.get('ime'),
            odjelID: podaci.get('odjel'),
            
        };

         dodaj(djelatnici);

    }

    return (

        <Container>
            <Form onSubmit={obradiSubmit}>

                
                <Form.Group controlId="ime">
                    <Form.Label>ime</Form.Label>
                    <Form.Control type="text" name="ime" />
                </Form.Group>

                <Form.Group controlId="prezime">
                    <Form.Label>prezime</Form.Label>
                    <Form.Control type="text" name="prezime" />
                </Form.Group>

                <Form.Group controlId="odjel">
                    <Form.Label>odjel</Form.Label>
                    <Form.Control type="text" name="odjel" required />
                </Form.Group>

               

                <hr />
                <Row>
                    <Col xs={6} sm={6} md={3} lg={6} xl={1} xxl={2}>
                        <Link className="btn btn-danger siroko" to={RoutesNames.DJELATNICI_PREGLED}>
                            Odustani
                        </Link>
                    </Col>
                    <Col xs={6} sm={6} md={9} lg={6} xl={1} xxl={10}>
                        <Button className="siroko" variant="primary" type="submit">
                            Dodaj
                        </Button>
                    </Col>
                </Row>

            </Form>
        </Container>

    );
}