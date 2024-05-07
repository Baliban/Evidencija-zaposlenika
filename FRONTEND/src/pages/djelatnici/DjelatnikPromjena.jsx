import React, { useState, useEffect } from "react";
import { Container, Form, FormSelect,Row,Col, Button} from "react-bootstrap";
import { useNavigate, useParams, Link } from "react-router-dom";
import { RoutesNames } from "../../constants";
import useLoading from '../../hooks/useLoading';
import useError from "../../hooks/useError";
import Service from "../../services/DjelatniciService";
import { FcServices } from "react-icons/fc";


export default function DjelatnikPromjena(){
    const navigate = useNavigate();
    const routeParams = useParams();
    const [djelatnik, setDjelatnik] = useState({});
    const { showLoading, hideLoading } = useLoading();
    const { prikaziError } = useError();

    async function dohvatiDjelatnika() {
        showLoading();
        const o = await Service.GetBySifra(routeParams.id);
        hideLoading();
        if (o.greska) {
            console.log(o.poruka);
            alert("Pogledaj konzolu");
            return;
        }
        console.log(o);
        setDjelatnik(o.poruka);
    }

    async function promjeni(djelatnici) {
        showLoading();
        const odgovor = await Service.promjeni(routeParams.id,djelatnici);
        hideLoading();
        if (odgovor.greska) {
            console.log(odgovor.poruka);
            alert("Pogledaj konzolu");
            return;
        }
        navigate(RoutesNames.DJELATNICI_PREGLED);
    }

    useEffect(() => {
        dohvatiDjelatnika();
    }, []);

    async function obradiSubmit(e) {
        e.preventDefault();

        const podaci = new FormData(e.target);
        const djelatnik = {
            ime: podaci.get('Ime'),
            prezime: podaci.get('prezime'),
            odjeID: parseInt(podaci.get('odjel')),
            
        };
        promjeni(djelatnik);
    }

    return (
        <Container>
            <Form onSubmit={obradiSubmit}>

                <Form.Group controlId="Ime">
                    <Form.Label>ime</Form.Label>
                    <Form.Control type="text" name="Ime" defaultValue={djelatnik.ime} required />
                </Form.Group>

                <Form.Group controlId="prezime">
                    <Form.Label>prezime</Form.Label>
                    <Form.Control type="text" name="prezime" defaultValue={djelatnik.prezime} required />
                </Form.Group>

                <Form.Group controlId="odjel">
                    <Form.Label>odjel</Form.Label>
                    <Form.Control type="number" name="odjel" defaultValue={djelatnik.odjeID} required />
                </Form.Group>

                <hr />
                <Row>
                <Col>
                        <Link className="btn btn-danger siroko" to={RoutesNames.DJELATNICI_PREGLED}>
                            Odustani
                        </Link>
                    </Col>
                    <Col>
                        <Button className="siroko" variant="primary" type="submit">
                            Promjeni
                        </Button>
                    </Col>
                </Row>

            </Form>
        </Container>







    );

}