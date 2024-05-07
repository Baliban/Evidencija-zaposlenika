import { useState, useEffect, useRef } from 'react';
import { Container, Form, Row, Col, Table, Button } from 'react-bootstrap';
import { useNavigate, useParams ,Link} from 'react-router-dom';
import moment from 'moment';
import { App, RoutesNames } from '../../constants';
import InputText from '../../components/InputText';
import Akcije from '../../components/Akcije';
import { AsyncTypeahead } from 'react-bootstrap-typeahead';
import { FaTrash } from 'react-icons/fa';
import useError from "../../hooks/useError";
import useLoading from "../../hooks/useLoading";
import RasporedService from '../../services/RasporedService';


export default function RasporedPromjeni() {
  const navigate = useNavigate();
    const routeParams = useParams();
    const [raspored, setRaspored] = useState({});
    const { showLoading, hideLoading } = useLoading();
    const { prikaziError } = useError();

    async function dohvatiRaspored() {
        showLoading();
        const o = await RasporedService.getBySifra(routeParams.ID);
        hideLoading();
        if (o.greska) {
            console.log(o.poruka);
            alert("Pogledaj konzolu");
            return;
        }
        console.log(o);
        setRaspored(o.poruka);
    }

    async function promjeni(raspored) {
        showLoading();
        const odgovor = await RasporedService.put(routeParams.ID,raspored);
        hideLoading();
        if (odgovor.greska) {
            console.log(odgovor.poruka);
            alert("Pogledaj konzolu");
            return;
        }
        navigate(RoutesNames.RASPOREDI_PREGLED);
    }

    useEffect(() => {
        dohvatiRaspored();
    }, []);

    async function obradiSubmit(e) {
        e.preventDefault();
    const podaci = new FormData(e.target);
   
        const raspored = {
            djelatnikID: podaci.get('djelatnikid'),
            ponedjeljak: podaci.get('ponedjeljak'),
            utorak: podaci.get('utorak'),
            srijeda: podaci.get('srijeda'),
            cetvrtak: podaci.get('cetvrtak'),
            petak: podaci.get('petak'),
            subota: podaci.get('subota'),
            nedjelja: podaci.get('nedjelja'),

        };
        promjeni(raspored);
    
  }

  return (
    <Container>
            <Form onSubmit={obradiSubmit}>

                <Form.Group controlId="djelatnikid">
                    <Form.Label>djelatnik</Form.Label>
                    <Form.Control type="number" name="djelatnikid" defaultValue={raspored.djelatnikID} required />
                </Form.Group>

                <Form.Group controlId="ponedjeljak">
                    <Form.Label>ponedjeljak</Form.Label>
                    <Form.Control type="number" name="ponedjeljak" defaultValue={raspored.ponedjeljak} required />
                </Form.Group>

                <Form.Group controlId="utorak">
                    <Form.Label>utorak</Form.Label>
                    <Form.Control type="number" name="utorak" defaultValue={raspored.utorak} required />
                </Form.Group>

                <Form.Group controlId="srijeda">
                    <Form.Label>srijeda</Form.Label>
                    <Form.Control type="number" name="srijeda" defaultValue={raspored.srijeda} required />
                </Form.Group>

                <Form.Group controlId="cetvrtak">
                    <Form.Label>cetvrtak</Form.Label>
                    <Form.Control type="number" name="cetvrtak" defaultValue={raspored.cetvrtak} required />
                </Form.Group>

                <Form.Group controlId="petak">
                    <Form.Label>petak</Form.Label>
                    <Form.Control type="nember" name="petak" defaultValue={raspored.petak} required />
                </Form.Group>

                <Form.Group controlId="subota">
                    <Form.Label>subota</Form.Label>
                    <Form.Control type="number" name="subota" defaultValue={raspored.subota} required />
                </Form.Group>

                <Form.Group controlId="nedjelja">
                    <Form.Label>nedjelja</Form.Label>
                    <Form.Control type="number" name="nedjelja" defaultValue={raspored.nedjelja} required />
                </Form.Group>

                <hr />
                <Row>
                <Col>
                        <Link className="btn btn-danger siroko" to={RoutesNames.RASPOREDI_PREGLED}>
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
        </Container>  );
}
