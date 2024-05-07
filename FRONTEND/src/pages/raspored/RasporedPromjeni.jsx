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
            DjelatniID: podaci.get('djelatnik'),
            Ponedjeljak: podaci.get('ponedjeljak'),
            Utorak: podaci.get('utorak'),
            Srijeda: podaci.get('srijeda'),
            Cetvrtak: podaci.get('cetvrtak'),
            Petak: podaci.get('petak'),
            Subota: podaci.get('subota'),
            Nedjelja: podaci.get('nedjelja'),

        };
        promjeni(raspored);
    
  }

  return (
    <Container>
            <Form onSubmit={obradiSubmit}>

                <Form.Group controlId="djelatnik">
                    <Form.Label>djelatnik</Form.Label>
                    <Form.Control type="text" name="djelatnik" defaultValue={raspored.DjelatniID} required />
                </Form.Group>

                <Form.Group controlId="ponedjeljak">
                    <Form.Label>ponedjeljak</Form.Label>
                    <Form.Control type="number" name="ponedjeljak" defaultValue={raspored.Ponedjeljak} required />
                </Form.Group>

                <Form.Group controlId="utorak">
                    <Form.Label>utorak</Form.Label>
                    <Form.Control type="number" name="utorak" defaultValue={raspored.Utorak} required />
                </Form.Group>

                <Form.Group controlId="srijeda">
                    <Form.Label>srijeda</Form.Label>
                    <Form.Control type="number" name="srijeda" defaultValue={raspored.Srijeda} required />
                </Form.Group>

                <Form.Group controlId="cetvrtak">
                    <Form.Label>cetvrtak</Form.Label>
                    <Form.Control type="number" name="cetvrtak" defaultValue={raspored.Cetvrtak} required />
                </Form.Group>

                <Form.Group controlId="petak">
                    <Form.Label>petak</Form.Label>
                    <Form.Control type="nember" name="petak" defaultValue={raspored.Petak} required />
                </Form.Group>

                <Form.Group controlId="subota">
                    <Form.Label>subota</Form.Label>
                    <Form.Control type="number" name="subota" defaultValue={raspored.Subota} required />
                </Form.Group>

                <Form.Group controlId="nedjelja">
                    <Form.Label>nedjelja</Form.Label>
                    <Form.Control type="number" name="nedjelja" defaultValue={raspored.Nedjelja} required />
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
