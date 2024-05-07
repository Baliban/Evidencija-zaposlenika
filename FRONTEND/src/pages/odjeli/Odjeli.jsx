import { useEffect, useState } from "react";
import { Button, Container, Table } from "react-bootstrap";
import Service from "../../services/OdjelService";
import { IoIosAdd } from "react-icons/io";
import { FaEdit, FaTrash } from "react-icons/fa";
import { Link, useNavigate } from "react-router-dom";
import { RoutesNames } from "../../constants";

export default function Odjel() {
  const [odjeli, setOdjel] = useState([]);
  const navigate = useNavigate();

  async function dohvatiOdjel() {
    const odgovor = await Service.get("Odjel");
    if (!odgovor.ok) {
      alert(Service.dohvatiPorukeAlert(odgovor.podaci));
      return;
    }
    setOdjel(odgovor.podaci);
  }

  async function obrisi(id) {
    const odgovor = await Service.obrisi("Odjel", id);
    alert(Service.dohvatiPorukeAlert(odgovor.podaci));
    if (odgovor.ok) {
      dohvatiOdjel();
    }
  }
  useEffect(() => {
    dohvatiOdjel();
    
  }, []);

  return (
    <Container>
      <Link to={RoutesNames.ODJELI_NOVI} className="btn btn-success siroko">
        <IoIosAdd size={25} /> Dodaj odjel
      </Link>
      <Table striped bordered hover responsive>
        <thead>
          <tr>
            <th>Naziv</th>
            

            <th>Akcija</th>
          </tr>
        </thead>
        <tbody>
          {odjeli &&
            odjeli.map((odjel, index) => (
              <tr key={index}>
                <td>{odjel.naziv}</td>
                

                <td className="sredina">
                  <Button
                    variant="primary"
                    onClick={() => {
                      navigate(`/odjel/${odjel.id}`);
                    }}
                  >
                    <FaEdit size={25} />
                  </Button>
                  &nbsp;&nbsp;&nbsp;
                  <Button variant="danger" onClick={() => obrisi(odjel.id)}>
                    <FaTrash size={25} />
                  </Button>
                </td>
              </tr>
            ))}
        </tbody>
      </Table>
    </Container>
  );
}