import React, { useState, useEffect } from "react";
import { Container, Form, FormSelect,Row,Col, Button} from "react-bootstrap";
import { useNavigate, useParams, Link } from "react-router-dom";
import moment from "moment";
//import Service from "../../services/DjelatniciService";
import { RoutesNames } from "../../constants";
import InputText from "../../components/InputText";
import Akcije from "../../components/Akcije";
import useLoading from '../../hooks/useLoading';
import useError from "../../hooks/useError";
//import { promjeni } from "../../services/HttpService";
import DjelatniciService from "../../services/DjelatniciService";
import { FaReply, FaSync } from "react-icons/fa";


export default function DjelatnikPromjena(){
    const navigate = useNavigate();
    const routeParams = useParams();
    const [djelatnik, setDjelatnik] = useState({});
    const { showLoading, hideLoading } = useLoading();
    const { prikaziError } = useError();

    async function dohvatiDjelatnika() {
        showLoading();
        const o = await DjelatniciService.GetBySifra(routeParams.ID);
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
        const odgovor = await DjelatniciService.put(routeParams.ID,djelatnici);
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
            Ime: podaci.get('Ime'),
            Prezime: podaci.get('prezime'),
            OdjelID: parseInt(podaci.get('odjel'))
            
        };
        promjeni(djelatnik);
    }

    return (
        <Container>
            <Form onSubmit={obradiSubmit}>

                <Form.Group controlId="Ime">
                    <Form.Label>ime</Form.Label>
                    <Form.Control type="text" name="Ime" defaultValue={djelatnik.Ime} required />
                </Form.Group>

                <Form.Group controlId="prezime">
                    <Form.Label>prezime</Form.Label>
                    <Form.Control type="text" name="prezime" defaultValue={djelatnik.Prezime} required />
                </Form.Group>

                <Form.Group controlId="odjel">
                    <Form.Label>odjel</Form.Label>
                    <Form.Control type="number" name="odjel" defaultValue={djelatnik.OdjelID} required />
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