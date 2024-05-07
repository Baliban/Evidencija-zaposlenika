import { useEffect, useState } from 'react';
//import Container from 'react-bootstrap/Container';
import { Button, Container, Table } from "react-bootstrap";
import { IoIosAdd } from "react-icons/io";
import { FaEdit, FaTrash } from "react-icons/fa";
import { Link ,useNavigate} from 'react-router-dom';
import {RoutesNames} from '../../constants'
import Service from '../../services/RasporedService';
//import Djelatnici from './pages/djelatnici/Djelatnici'


export default function Raspored(){
    const [rasporedi, setRaspored] = useState([]);
    const navigate = useNavigate();
    
    async function dohvatiRaspored() {
      const odgovor = await Service.get("Raspored");
      if (!odgovor.ok) {
        alert(Service.dohvatiPorukeAlert(odgovor.podaci));
        return;
      }
      setRaspored(odgovor.podaci);
    }
  
    async function obrisi(ID) {
      const odgovor = await Service.obrisi("Raspored", ID);
      alert(Service.dohvatiPorukeAlert(odgovor.podaci));
      if (odgovor.ok) {
        dohvatiRaspored();
      }
    }
    useEffect(() => {
      dohvatiRaspored();
    
        },[]);

  

    return(
        <>
           <Container>
           <Link to={RoutesNames.RASPOREDI_NOVI} className="btn btn-success siroko">
        <IoIosAdd size={25} /> Dodaj </Link>
            <Table striped bordered hover responsive>
                    <thead>
                        <tr>
                            <th>Ime i odjel</th>
                            
                            <th>Ponedjeljak</th>
                            <th>Utorak</th>
                            <th>Srijeda</th>
                            <th>Cetvrtak</th>
                            <th>Petak</th>
                            <th>Subota</th>
                            <th>Nedjelja</th>
                            
                        </tr>
                    </thead>
                    <tbody>
                        {rasporedi && rasporedi.map ((raspored, index)=>(
                            <tr key={index}>
                                <td>{raspored.djelatnikImePrezimeOdjel}</td>
                                <td>{raspored.ponedjeljak}</td>
                                <td>{raspored.utorak}</td>
                                <td>{raspored.srijeda}</td>
                                <td>{raspored.cetvrtak}</td>
                                <td>{raspored.petak}</td>
                                <td>{raspored.subota}</td>
                                <td>{raspored.nedjelja}</td>
                                <td className="sredina">
                  <Button
                    variant="primary"
                    onClick={() => {
                      navigate(`/Raspored/${raspored.ID}`);
                    }}
                  >
                    <FaEdit size={25} />
                  </Button>
                  &nbsp;&nbsp;&nbsp;
                  <Button variant="danger" onClick={() => obrisi(raspored.ID)}>
                    <FaTrash size={25} />
                  </Button>
                </td> 
                                
                            </tr>
                        ))}
                    </tbody>
            </Table>
           </Container>
        </>
    );
}


