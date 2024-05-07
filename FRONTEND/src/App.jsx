import 'bootstrap/dist/css/bootstrap.min.css'
import './App.css'
import NavBar from './components/NavBar'
import { Route, Routes } from 'react-router-dom'
import { RoutesNames } from './constants'
import Pocetna from './pages/Pocetna'
import Djelatnici from './pages/djelatnici/Djelatnici'
import DjelatnikDodaj from './pages/djelatnici/DjelatnikDodaj'
import DjelatnikPromjena from './pages/djelatnici/DjelatnikPromjena'
import Raspored from './pages/raspored/Raspored'
import RasporedDodaj from './pages/raspored/RasporedDodaj'
import ErrorModal from './components/ErrorModal';
import useError from "./hooks/useError"
import LoadingSpinner from './components/LoadingSpinner'
import RasporedPromjeni from './pages/raspored/RasporedPromjeni'
import Odjeli from './pages/odjeli/Odjeli'
import OdjeliDodaj from './pages/odjeli/OdjeliDodaj'
import OdjeliPromjeni from './pages/odjeli/OdjeliPromjeni'


function App() {

  const { errors, prikaziErrorModal, sakrijError } = useError();

  return (
    <>
    <ErrorModal show={prikaziErrorModal} errors={errors} onHide={sakrijError} />
      <LoadingSpinner />
      <NavBar />
      <Routes>
        <Route path={RoutesNames.HOME} element={<Pocetna />} />
        <Route path={RoutesNames.DJELATNICI_PREGLED} element={<Djelatnici />} />
        <Route path={RoutesNames.DJELATNICI_NOVI} element={<DjelatnikDodaj />} />
        <Route path={RoutesNames.DJELATNICI_PROMJENI} element={<DjelatnikPromjena />} />
        <Route path={RoutesNames.RASPOREDI_PREGLED} element={<Raspored />} />
        <Route path={RoutesNames.RASPOREDI_NOVI} element={<RasporedDodaj />} />
        <Route path={RoutesNames.RASPOREDI_PROMJENI} element={<RasporedPromjeni />} />
        <Route path={RoutesNames.ODJELI_PREGLED} element={<Odjeli />} />
        <Route path={RoutesNames.ODJELI_NOVI} element={<OdjeliDodaj />} />
        <Route path={RoutesNames.ODJELI_PROMJENI} element={<OdjeliPromjeni />} />
        
      </Routes>
    </>
  )
}

export default App
