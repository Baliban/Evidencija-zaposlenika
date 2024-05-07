import  {get,obrisi,dodaj,getBySifra,promjeni,dohvatiPorukeAlert, obradiUspjeh, obradiGresku, HttpService } from "./HttpService";

const path = '/Raspored'

async function getDjelatnici(naziv,sifra){
    return await HttpService.get('/' + naziv + '/Djelatnici/' + sifra).then((res)=>{return obradiUspjeh(res);}).catch((e)=>{ return obradiGresku(e);});
  }
  async function dodajDjelatnika(naziv,raspored, djelatnik) {
    return await HttpService.post('/' + naziv + '/' + raspored + '/dodaj/' + djelatnik).then((res)=>{return obradiUspjeh(res);}).catch((e)=>{ return obradiGresku(e);});
  }
  async function obrisiDjelatnika(naziv,raspored, djelatnik) {
    return await HttpService.delete('/'+naziv+'/' + raspored + '/obrisi/' + djelatnik).then((res)=>{return obradiUspjeh(res);}).catch((e)=>{ return obradiGresku(e);});
  }

  async function post(raspored){
    return await HttpService.post(path, raspored)
    .then((odgovor)=>{
        console.table(odgovor.data);
        return {greska: false, poruka: odgovor.data};
    })
    .catch((e)=>{
        console.log(e);
        return {greska: true, poruka: e};
    })
}

export default{
    get,
    obrisi,
    dodaj,
    promjeni,
    getBySifra,
    dohvatiPorukeAlert,
    post,

    getDjelatnici,
    dodajDjelatnika,
    obrisiDjelatnika
};