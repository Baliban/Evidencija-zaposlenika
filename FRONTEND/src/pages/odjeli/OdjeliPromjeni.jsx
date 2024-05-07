import React, { useState, useEffect } from "react";
import { Container, Form, FormSelect,Row,Col, Button} from "react-bootstrap";
import { useNavigate, useParams, Link } from "react-router-dom";
import { RoutesNames } from "../../constants";
import InputText from "../../components/InputText";
import Akcije from "../../components/Akcije";
import useLoading from '../../hooks/useLoading';
import useError from "../../hooks/useError";
import { FaReply, FaSync } from "react-icons/fa";
import OdjelService from "../../services/OdjelService";



export default function OdjeliPromjeni(){
    const navigate = useNavigate();
    const routeParams = useParams();
    const [odjel, setOdjel] = useState({});
    const { showLoading, hideLoading } = useLoading();
    const { prikaziError } = useError();

    async function dohvatiOdjel() {
        showLoading();
        const o = await OdjelService.getBySifra(routeParams.ID);
        hideLoading();
        if (o.greska) {
            console.log(o.poruka);
            alert("Pogledaj konzolu");
            return;
        }
        console.log(o);
        setOdjel(o.poruka);
    }

    async function promjeni(odjel) {
        showLoading();
        const odgovor = await OdjelService.put(routeParams.ID,odjel);
        hideLoading();
        if (odgovor.greska) {
            console.log(odgovor.poruka);
            alert("Pogledaj konzolu");
            return;
        }
        navigate(RoutesNames.ODJELI_PREGLED);
    }

    useEffect(() => {
        dohvatiOdjel();
    }, []);

    async function obradiSubmit(e) {
        e.preventDefault();

        const podaci = new FormData(e.target);
        const odjel = {
            Naziv: podaci.get('naziv'),
            
        };
        promjeni(odjel);
    }

    return (
        <Container>
            <Form onSubmit={obradiSubmit}>

                <Form.Group controlId="naziv">
                    <Form.Label>naziv</Form.Label>
                    <Form.Control type="text" name="naziv" defaultValue={odjel.Naziv} required />
                </Form.Group>

                <hr />
                <Row>
                <Col>
                        <Link className="btn btn-danger siroko" to={RoutesNames.ODJELI_PREGLED}>
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