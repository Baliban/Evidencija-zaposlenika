import { useEffect, useState } from "react";
import { Button, Container, Table } from "react-bootstrap";
import Service from "../../services/DjelatniciService";
import { IoIosAdd } from "react-icons/io";
import { FaEdit, FaTrash } from "react-icons/fa";
import { Link, useNavigate } from "react-router-dom";
import { RoutesNames } from "../../constants";

export default function Djelatnici() {
  const [djelatnici, setDjelatnici] = useState([]);
  const navigate = useNavigate();

  async function dohvatiDjelatnike() {
    const odgovor = await Service.get("Djelatnici");
    if (!odgovor.ok) {
      alert(Service.dohvatiPorukeAlert(odgovor.podaci));
      return;
    }
    setDjelatnici(odgovor.podaci);
  }

  async function obrisi(ID) {
    const odgovor = await Service.obrisi("Djelatnici", ID);
    alert(Service.dohvatiPorukeAlert(odgovor.podaci));
    if (odgovor.ok) {
      dohvatiDjelatnike();
    }
  }
  useEffect(() => {
    dohvatiDjelatnike();
    
  }, []);

  return (
    <Container>
      <Link to={RoutesNames.DJELATNICI_NOVI} className="btn btn-success siroko">
        <IoIosAdd size={25} /> Dodaj
      </Link>
      <Table striped bordered hover responsive>
        <thead>
          <tr>
            <th>Ime</th>
            <th>Prezime</th>
            <th>Odjel</th>

            <th>Akcija</th>
          </tr>
        </thead>
        <tbody>
          {djelatnici &&
            djelatnici.map((djelatnik, index) => (
              <tr key={index}>
                <td>{djelatnik.ime}</td>
                <td>{djelatnik.prezime}</td>
                <td>{djelatnik.odjelNaziv}</td>

                <td className="sredina">
                  <Button
                    variant="primary"
                    onClick={() => {
                      navigate(`/Djelatnici/${djelatnik.ID}`);
                    }}
                  >
                    <FaEdit size={25} />
                  </Button>
                  &nbsp;&nbsp;&nbsp;
                  <Button variant="danger" onClick={() => obrisi(djelatnik.ID)}>
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