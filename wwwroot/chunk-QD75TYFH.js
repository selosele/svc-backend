import{Qb as h,Yb as p,bc as m,db as u,ec as v,q as r,t as s}from"./chunk-M3GQJLHA.js";var d=(()=>{let e=class e extends m{constructor(){super()}init(){this.creates([{key:"vacationResponse",defaultValue:null},{key:"vacationTableTitle",defaultValue:null},{key:"vacationTableText",defaultValue:null},{key:"vacationStatResponse",defaultValue:null},{key:"vacationStatResponseDataLoad",defaultValue:!1},{key:"vacationWorkHistoryList",defaultValue:[]},{key:"vacationWorkHistoryTabList",defaultValue:[]},{key:"vacationWorkHistoryTabIndex",defaultValue:0},{key:"vacationWorkHistoryListDataLoad",defaultValue:!1},{key:"vacationWorkHistoryId",defaultValue:null}])}};e.\u0275fac=function(a){return new(a||e)},e.\u0275prov=r({token:e,factory:e.\u0275fac,providedIn:"root"});let o=e;return o})();var S=(()=>{let e=class e{constructor(t,a,i){this.http=t,this.httpService=a,this.vacationStore=i}listVacation$(t){let a=this.httpService.createParams(t);return this.http.get("/hm/vacations",{params:a})}getVacation$(t){return this.http.get(`/hm/vacations/${t}`)}addVacation$(t){return this.http.post("/hm/vacations",t)}updateVacation$(t){let{vacationId:a}=t;return this.http.put(`/hm/vacations/${a}`,t)}removeVacation$(t){return this.http.delete(`/hm/vacations/${t}`)}listVacationCalc$(t){return this.http.get(`/hm/vacations/calcs/${t}`)}addVacationCalc$(t){let{workHistoryId:a}=t;return this.http.post(`/hm/vacations/calcs/${a}`,t)}listVacationStats$(t){let a=this.httpService.createParams(t);return this.http.get("/hm/vacations/stats",{params:a})}listVacationByMonth$(t){let a=this.httpService.createParams(t);return this.http.get("/hm/vacations/stats/month",{params:a})}setVacationTableContent(t){let a=this.vacationStore.select("vacationWorkHistoryList").value[t];this.vacationStore.update("vacationTableTitle",this.showVacationCount(a)),this.vacationStore.update("vacationTableText",this.setVacationTableText(a))}setVacationTableText(t){let a="",{annualTypeCode:i,joinYmd:c,quitYmd:n,vacationTotalCountByJoinYmd:l}=t;switch(i){case"JOIN_YMD":let f=h(c).format("YYYY\uB144 MM\uC6D4 DD\uC77C");return a+=`\uC785\uC0AC ${f}\uBD80\uD130 \uCD1D <strong>${l}</strong>\uAC1C\uC758 \uC6D4\uCC28\uAC00 \uBC1C\uC0DD\uD588\uC5B4\uC694.`,p(n)&&(a+=`<br>\uD1F4\uC0AC\uD588\uC744 \uACBD\uC6B0 \uD1F4\uC0AC\uC77C\uC790(${n})\uB97C \uAE30\uC900\uC73C\uB85C \uB9C8\uC9C0\uB9C9 \uC6D4\uCC28 \uAC1C\uC218\uAC00 \uACC4\uC0B0\uB3FC\uC694.`),a;case"FISCAL_YEAR":return a+=`
          \uADFC\uB85C\uAE30\uC900\uBC95 \uC81C60\uC870 4\uD56D\uC5D0 \uC758\uAC70, 3\uB144 \uC774\uC0C1 \uADFC\uC18D\uD588\uC744 \uACBD\uC6B0 2\uB144\uB9C8\uB2E4 1\uC77C\uC529 \uAC00\uC0B0\uB41C \uC720\uAE09\uD734\uAC00\uAC00 \uBD80\uC5EC\uB3FC\uC694.<br>
          \uC774 \uACBD\uC6B0 \uAC00\uC0B0\uD734\uAC00\uB97C \uD3EC\uD568\uD55C \uCD1D \uD734\uAC00 \uC77C\uC218\uB294 25\uC77C\uC744 \uD55C\uB3C4\uB85C \uD558\uACE0 \uC788\uC5B4\uC694.
        `,a;default:return a}}showVacationCount(t){let{annualTypeCode:a,vacationTotalCountByJoinYmd:i,vacationTotalCountByFiscalYear:c,vacationRemainCountByJoinYmd:n,vacationRemainCountByFiscalYear:l}=t;switch(a){case"JOIN_YMD":return`\uC794\uC5EC \uC6D4\uCC28: <strong class="text-primary">${n}</strong>/${i}\uAC1C`;case"FISCAL_YEAR":return`\uC794\uC5EC \uC5F0\uCC28: <strong class="text-primary">${l}</strong>/${c}\uAC1C`;default:return null}}setWorkHistoryId(t){this.vacationStore.update("vacationWorkHistoryId",t)}};e.\u0275fac=function(a){return new(a||e)(s(u),s(v),s(d))},e.\u0275prov=r({token:e,factory:e.\u0275fac,providedIn:"root"});let o=e;return o})();export{d as a,S as b};
