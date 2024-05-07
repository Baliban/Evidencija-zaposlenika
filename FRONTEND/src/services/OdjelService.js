import {get,obrisi,dodaj,getBySifra,promjeni,dohvatiPorukeAlert,HttpService} from "./HttpService";

const path = '/Odjel'

async function post(Odjel){
    return await HttpService.post(path, Odjel)
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
    post
    

    
}