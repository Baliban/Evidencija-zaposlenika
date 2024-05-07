import { Button, Col, Container, Form, Row } from "react-bootstrap";
import { Link, useNavigate } from "react-router-dom";
import { RoutesNames } from "../../constants";
import OdjelService from "../../services/OdjelService";


export default function OdjelDodaj(){
    const navigate = useNavigate();

    async function dodaj(odjeli){
        const odgovor = await OdjelService.post(odjeli);
        if (odgovor.greska){
            console.log(odgovor.poruka);
            alert('Pogledaj konzolu');
            return;
        }
        navigate(RoutesNames.ODJELI_PREGLED);
    }

    function obradiSubmit(e){ 
        e.preventDefault();
        

        const podaci = new FormData(e.target);

        const odjel = {
            
            Naziv: podaci.get('naziv'), 
           
            
        };

         dodaj(odjel);

    }

    return (

        <Container>
            <Form onSubmit={obradiSubmit}>

                
                <Form.Group controlId="naziv">
                    <Form.Label>Naziv</Form.Label>
                    <Form.Control type="text" name="naziv" />
                </Form.Group>

                

               

                <hr />
                <Row>
                    <Col xs={6} sm={6} md={3} lg={6} xl={1} xxl={2}>
                        <Link className="btn btn-danger siroko" to={RoutesNames.ODJELI_PREGLED}>
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