import Djelatnici from "../pages/djelatnici/Djelatnici";
import  {get,promjeni,dodaj,obrisi,getBySifra,dohvatiPorukeAlert, obradiUspjeh, obradiGresku,HttpService} from "./HttpService";

const brisidjelatnik = '/Djelatnici'
// async function get(){
//     return await HttpService.get(brisidjelatnik)
//     .then((odgovor)=>{
//         console.table(odgovor.data);
//         return odgovor.data;
//     })
//     .catch((e)=>{
//         console.log(e);
//         return e;
//     })
// }

async function post(djelatnik){
    return await HttpService.post(brisidjelatnik, djelatnik)
    .then((odgovor)=>{
        console.table(odgovor.data);
        return {greska: false, poruka: odgovor.data};
    })
    .catch((e)=>{
        console.log(e);
        return {greska: true, poruka: e};
    })
}
async function put(ID,djelatnici){
    return await HttpService.put(brisidjelatnik + '/' + ID , djelatnici)
    .then((odgovor)=>{
        console.table(odgovor.data);
        return {greska: false, poruka: odgovor.data};
    })
    .catch((e)=>{
        console.log(e);
        return {greska: true, poruka: e};
    })
}

// async function _delete(id){
//     return await HttpService.delete(brisidjelatnik + '/' + id)
//     .then((odgovor)=>{
//         console.table(odgovor.data);
//         return {greska: false, poruka: odgovor.data.poruka};
//     })
//     .catch((e)=>{
//         console.log(e);
//         return {greska: true, poruka: e};
//     })
// }
async function GetBySifra(ID){
    return await HttpService.get(brisidjelatnik+'/'+ID)
    .then((o)=>{
        return {greska: false, poruka: o.data}
    })
    .catch((e)=>{
        return {greska: true, poruka: e}
    });
}
export default{
    get,
    obrisi,
    promjeni,
    getBySifra,
    dohvatiPorukeAlert,
    obradiUspjeh,
    obradiGresku,
    dodaj,
    post,
    put,
    GetBySifra
    
    
    
}