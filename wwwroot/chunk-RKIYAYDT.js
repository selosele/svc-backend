import{bc as u,db as n,n as s,q as c,t as a}from"./chunk-M3GQJLHA.js";var p=(()=>{let o=class o extends u{constructor(){super()}init(){this.creates([{key:"codeList",defaultValue:[]},{key:"codeListDataLoad",defaultValue:!1},{key:"codeTree",defaultValue:[]}])}};o.\u0275fac=function(t){return new(t||o)},o.\u0275prov=c({token:o,factory:o.\u0275fac,providedIn:"root"});let r=o;return r})();var v=(()=>{let o=class o{constructor(e,t){this.http=e,this.codeStore=t}setCodeList(e){let t=this.createCodeTree(e);this.codeStore.update("codeTree",t),this.codeStore.update("codeList",e)}listCode$(){return this.http.get("/co/codes").pipe(s(e=>{this.setCodeList(e.codeList),this.codeStore.update("codeListDataLoad",!0)}))}getCode$(e){return this.http.get(`/co/codes/${e}`)}addCode$(e){return this.http.post("/co/codes",e)}updateCode$(e){let{codeId:t}=e;return this.http.put(`/co/codes/${t}`,e)}removeCode$(e){return this.http.delete(`/co/codes/${e}`)}createCodeData(e){return this.codeStore.select("codeList").value.filter(t=>t.upCodeId===e).map(t=>({label:t.codeName,value:t.codeValue}))}createYnCodeData(){return[{label:"Y",value:"Y"},{label:"N",value:"N"}]}createCodeTree(e,t=null){let d=[];for(let i of e)if(i.upCodeId===t){let l=this.createCodeTree(e,i.codeId);d.push({data:i,children:l,expanded:!1})}return d}};o.\u0275fac=function(t){return new(t||o)(a(n),a(p))},o.\u0275prov=c({token:o,factory:o.\u0275fac,providedIn:"root"});let r=o;return r})();export{p as a,v as b};
