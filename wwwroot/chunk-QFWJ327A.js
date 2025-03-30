import{F as P,f as $,l as k,n as Y,o as d,p as M,q,r as X,s as Q,t as g}from"./chunk-7VAYUDPN.js";import{A as y,Da as S,Dc as I,E as _,Ec as L,K as n,L as f,T as R,Uc as j,V as w,Vb as K,X as r,Zb as W,aa as b,ea as s,fa as m,fd as U,ga as p,id as O,jb as H,ka as V,la as h,ma as c,qa as E,ra as B,sa as T,tc as G,ua as N,v,y as F,z as C,zc as x}from"./chunk-M3GQJLHA.js";import"./chunk-M6OTSRMF.js";import"./chunk-FK6H3RFT.js";import{f as D}from"./chunk-USDYGGWM.js";var Z=(()=>{let o=class o{constructor(t,e,i){this.fb=t,this.messageService=e,this.companyService=i,this.detail=null,this.useRemove=!0,this.refresh=new _,this.remove=new _,this.close=new _}ngOnInit(){this.detailForm=this.fb.group({companyId:[""],corporateName:["",[d.required,d.maxLength(100)]],companyName:["",[d.required,d.maxLength(100)]],registrationNo:["",[d.maxLength(10)]],ceoName:["",[d.maxLength(30)]],companyAddr:["",[d.maxLength(255)]]})}ngOnChanges(t){if(t.detail&&this.detailForm){if(this.useRemove=!0,W(t.detail.currentValue)){this.useRemove=!1,this.detailForm.reset();return}this.detailForm.patchValue(this.detail)}}onSubmit(t){return D(this,null,function*(){let e=K(t.companyId)?"\uB4F1\uB85D":"\uC218\uC815";(yield this.messageService.confirm1(`\uD68C\uC0AC \uC815\uBCF4\uB97C ${e}\uD558\uC2DC\uACA0\uC5B4\uC694?`))&&(K(t.companyId)?this.companyService.addCompany$(t).subscribe(u=>{this.messageService.toastSuccess(`\uC815\uC0C1\uC801\uC73C\uB85C ${e}\uB418\uC5C8\uC5B4\uC694.`),this.detailForm.get("companyId").patchValue(u.company.companyId),this.refresh.emit()}):this.companyService.updateCompany$(t).subscribe(u=>{this.messageService.toastSuccess(`\uC815\uC0C1\uC801\uC73C\uB85C ${e}\uB418\uC5C8\uC5B4\uC694.`),this.refresh.emit()}))})}onRemove(t){return D(this,null,function*(){(yield this.messageService.confirm2("\uD68C\uC0AC\uB97C \uC0AD\uC81C\uD558\uC2DC\uACA0\uC5B4\uC694?<br>\uC774 \uC791\uC5C5\uC740 \uBCF5\uAD6C\uD560 \uC218 \uC5C6\uC5B4\uC694."))&&this.companyService.removeCompany$(this.detail.companyId).subscribe(()=>{this.messageService.toastSuccess("\uC815\uC0C1\uC801\uC73C\uB85C \uC0AD\uC81C\uB418\uC5C8\uC5B4\uC694."),this.remove.emit()})})}onClose(){this.close.emit()}};o.\u0275fac=function(e){return new(e||o)(f(j),f(O),f(g))},o.\u0275cmp=v({type:o,selectors:[["system-company-detail"]],inputs:{detail:"detail"},outputs:{refresh:"refresh",remove:"remove",close:"close"},standalone:!0,features:[F,S],decls:14,vars:14,consts:[[3,"submit","remove","close","form","useRemove"],[3,"control"],[3,"text"],[1,"grid","mt-2"],[1,"col-6"],[3,"control","label"],[1,"col-12"]],template:function(e,i){e&1&&(s(0,"ui-split-form",0),h("submit",function(A){return i.onSubmit(A)})("remove",function(A){return i.onRemove(A)})("close",function(){return i.onClose()}),p(1,"ui-hidden-field",1)(2,"ui-content-title",2),s(3,"div",3)(4,"div",4),p(5,"ui-text-field",5),m(),s(6,"div",4),p(7,"ui-text-field",5),m(),s(8,"div",4),p(9,"ui-text-field",5),m(),s(10,"div",4),p(11,"ui-text-field",5),m(),s(12,"div",6),p(13,"ui-text-field",5),m()()()),e&2&&(r("form",i.detailForm)("useRemove",i.useRemove),n(),r("control",i.detailForm.get("companyId")),n(),r("text","\uD68C\uC0AC \uC815\uBCF4"),n(3),r("control",i.detailForm.get("corporateName"))("label","\uBC95\uC778\uBA85"),n(2),r("control",i.detailForm.get("companyName"))("label","\uD68C\uC0AC\uBA85"),n(2),r("control",i.detailForm.get("registrationNo"))("label","\uC0AC\uC5C5\uC790\uB4F1\uB85D\uBC88\uD638"),n(2),r("control",i.detailForm.get("ceoName"))("label","\uB300\uD45C\uC790\uBA85"),n(2),r("control",i.detailForm.get("companyAddr"))("label","\uD68C\uC0AC \uC18C\uC7AC\uC9C0"))},dependencies:[M,k,q,x]});let a=o;return a})();function ne(a,o){if(a&1&&(s(0,"div",7),p(1,"ui-textarea",5),m()),a&2){let l=c();n(),r("control",l.detailForm.get("rejectContent"))("label","\uBC18\uB824 \uC0AC\uC720")}}var ee=(()=>{let o=class o{constructor(t,e,i,u){this.fb=t,this.route=e,this.messageService=i,this.companyService=u,this.detail=null,this.useRemove=!1,this.isRejectable=!1,this.refresh=new _,this.remove=new _,this.close=new _}ngOnInit(){this.route.data.subscribe(({code:t})=>{this.applyStateCodes=t.APPLY_STATE_00.filter(e=>e.value!="ACCEPT"&&e.value!="CONFIRM")}),this.detailForm=this.fb.group({companyApplyId:[""],corporateName:["",[d.required,d.maxLength(100)]],companyName:["",[d.required,d.maxLength(100)]],registrationNo:["",[d.maxLength(10)]],applyStateCode:[""],applicantName:[""],rejectContent:[""],applyDt:[""],applyContent:["",[d.maxLength(100)]],applicantId:[""]})}ngOnChanges(t){t.detail&&this.detailForm&&(this.detail.applyStateCode==="REJECT"?(this.isRejectable=!0,this.detailForm.get("rejectContent").setValidators([d.required])):(this.isRejectable=!1,this.detailForm.get("rejectContent").clearValidators()),this.detailForm.patchValue(this.detail),this.detailForm.get("rejectContent").updateValueAndValidity(),this.applyStateCodeName=this.detail.applyStateCodeName)}onApplyStateCodeChange(t){this.applyStateCodeName=this.applyStateCodes.find(e=>e.value===t.value).label,this.detailForm.get("rejectContent").patchValue(""),t.value==="REJECT"?(this.isRejectable=!0,this.detailForm.get("rejectContent").setValidators([d.required])):(this.isRejectable=!1,this.detailForm.get("rejectContent").clearValidators()),this.detailForm.get("rejectContent").updateValueAndValidity()}onSubmit(t){return D(this,null,function*(){if(t.applyStateCode==="NEW"){this.messageService.toastInfo("\uC2E0\uCCAD\uC0C1\uD0DC - \uC2B9\uC778 \uB610\uB294 \uBC18\uB824 \uC911 \uD558\uB098\uB97C \uC120\uD0DD\uD574\uC8FC\uC138\uC694.");return}(yield this.messageService.confirm1(`${this.applyStateCodeName}\uD558\uC2DC\uACA0\uC5B4\uC694?`))&&this.companyService.updateCompanyApply$(t).subscribe(i=>{this.messageService.toastSuccess(`\uC815\uC0C1\uC801\uC73C\uB85C ${this.applyStateCodeName}\uB418\uC5C8\uC5B4\uC694.`),this.refresh.emit()})})}onClose(){this.close.emit()}};o.\u0275fac=function(e){return new(e||o)(f(j),f(H),f(O),f(g))},o.\u0275cmp=v({type:o,selectors:[["system-company-apply-detail"]],inputs:{detail:"detail"},outputs:{refresh:"refresh",remove:"remove",close:"close"},standalone:!0,features:[F,S],decls:19,vars:23,consts:[[3,"submit","close","form","useRemove"],[3,"control"],[3,"text"],[1,"grid","mt-2"],[1,"col-6"],[3,"control","label"],[3,"change","control","label","data"],[1,"col-12"],[3,"control","label","readonly"]],template:function(e,i){e&1&&(s(0,"ui-split-form",0),h("submit",function(A){return i.onSubmit(A)})("close",function(){return i.onClose()}),p(1,"ui-hidden-field",1)(2,"ui-content-title",2),s(3,"div",3)(4,"div",4),p(5,"ui-text-field",5),m(),s(6,"div",4),p(7,"ui-text-field",5),m(),s(8,"div",4),p(9,"ui-text-field",5),m(),s(10,"div",4)(11,"ui-dropdown",6),h("change",function(A){return i.onApplyStateCodeChange(A)}),m()(),w(12,ne,2,2,"div",7),s(13,"div",4),p(14,"ui-text-field",8),m(),s(15,"div",4),p(16,"ui-text-field",8),m(),s(17,"div",7),p(18,"ui-textarea",8),m()()()),e&2&&(r("form",i.detailForm)("useRemove",i.useRemove),n(),r("control",i.detailForm.get("companyApplyId")),n(),r("text","\uD68C\uC0AC\uB4F1\uB85D\uC2E0\uCCAD \uC815\uBCF4"),n(3),r("control",i.detailForm.get("corporateName"))("label","\uBC95\uC778\uBA85"),n(2),r("control",i.detailForm.get("companyName"))("label","\uD68C\uC0AC\uBA85"),n(2),r("control",i.detailForm.get("registrationNo"))("label","\uC0AC\uC5C5\uC790\uB4F1\uB85D\uBC88\uD638"),n(2),r("control",i.detailForm.get("applyStateCode"))("label","\uC2E0\uCCAD\uC0C1\uD0DC")("data",i.applyStateCodes),n(),b(i.isRejectable?12:-1),n(2),r("control",i.detailForm.get("applicantName"))("label","\uC2E0\uCCAD\uC790\uBA85")("readonly",!0),n(2),r("control",i.detailForm.get("applyDt"))("label","\uC2E0\uCCAD\uC77C\uC2DC")("readonly",!0),n(2),r("control",i.detailForm.get("applyContent"))("label","\uC2E0\uCCAD \uB0B4\uC6A9")("readonly",!0))},dependencies:[M,k,X,Y,q,x]});let a=o;return a})();var ae=["splitter"];function se(a,o){a&1&&p(0,"ui-skeleton")(1,"ui-skeleton")(2,"ui-skeleton")}function le(a,o){if(a&1){let l=V();s(0,"ui-splitter",null,0)(2,"ui-table",2,1),h("refresh",function(){C(l);let e=c();return y(e.onRefresh())})("rowSelect",function(e){C(l);let i=c();return y(i.onRowSelect(e))})("unRowSelect",function(e){C(l);let i=c();return y(i.onRowUnselect(e))}),m(),s(4,"div",3)(5,"system-company-apply-detail",4),h("refresh",function(){C(l);let e=c();return y(e.onRefresh2())})("remove",function(){C(l);let e=c();return y(e.onRemove())})("close",function(){C(l);let e=c();return y(e.onClose())}),m()()()}if(a&2){let l=c();n(2),r("useAdd",!1)("useRemove",!1)("cols",l.cols)("data",l.companyApplyList)("dataKey","companyApplyId")("selection",l.selection),n(3),r("detail",l.detail)}}var te=(()=>{let o=class o extends ${constructor(t,e){super(),this.companyStore=t,this.companyService=e,this.cols=[{field:"companyName",header:"\uD68C\uC0AC\uBA85"},{field:"corporateName",header:"\uBC95\uC778\uBA85"},{field:"registrationNo",header:"\uC0AC\uC5C5\uC790\uB4F1\uB85D\uBC88\uD638"},{field:"applyDt",header:"\uC2E0\uCCAD\uC77C\uC2DC"},{field:"applicantName",header:"\uC2E0\uCCAD\uC790\uBA85"},{field:"applyStateCodeName",header:"\uC2E0\uCCAD\uC0C1\uD0DC",valueGetter:i=>`<span class="px-3 py-1 ${this.getColorClass(i.applyStateCode)}">${i.applyStateCodeName}</span>`}],this.detail=null,this.refresh=new _}get companyApplyList(){return this.companyStore.select("companyApplyList").value}get companyApplyListDataLoad(){return this.companyStore.select("companyApplyListDataLoad").value}ngOnInit(){!this.companyApplyListDataLoad&&this.user&&this.listCompanyApply()}listCompanyApply(){this.companyService.listCompanyApply()}onRefresh(){this.listCompanyApply()}onRefresh2(){this.listCompanyApply(),this.refresh.emit()}onRowSelect(t){this.companyService.getCompanyApply$(t.data.companyApplyId).subscribe(e=>{this.detail=e.companyApply,this.splitter.show()})}onRowUnselect(t){this.detail={},this.splitter.hide()}onRemove(){this.splitter.hide(),this.listCompanyApply()}onClose(){this.splitter.hide()}getColorClass(t){return t==="NEW"?"bg-primary-reverse":t==="APPROVAL"?"bg-primary text-white":t==="REJECT"?"bg-red-500 text-white":""}};o.\u0275fac=function(e){return new(e||o)(f(Q),f(g))},o.\u0275cmp=v({type:o,selectors:[["view-system-company-apply"]],viewQuery:function(e,i){if(e&1&&E(ae,5),e&2){let u;B(u=T())&&(i.splitter=u.first)}},outputs:{refresh:"refresh"},standalone:!0,features:[R,S],decls:6,vars:1,consts:[["splitter",""],["table",""],["first","",3,"refresh","rowSelect","unRowSelect","useAdd","useRemove","cols","data","dataKey","selection"],["second",""],[3,"refresh","remove","close","detail"]],template:function(e,i){e&1&&(s(0,"layout-page-description")(1,"ul")(2,"li"),N(3,"\uD68C\uC0AC\uB4F1\uB85D\uC2E0\uCCAD \uAC74\uC744 \uC2B9\uC778/\uBC18\uB824\uD560 \uC218 \uC788\uC5B4\uC694."),m()()(),w(4,se,3,0)(5,le,6,7,"ui-splitter")),e&2&&(n(4),b(i.companyApplyListDataLoad?5:4))},dependencies:[I,L,U,P,ee]});let a=o;return a})();var me=["splitter"];function pe(a,o){a&1&&p(0,"ui-skeleton")(1,"ui-skeleton")(2,"ui-skeleton")}function ce(a,o){if(a&1){let l=V();s(0,"ui-splitter",null,0)(2,"ui-table",5,1),h("refresh",function(){C(l);let e=c();return y(e.onRefresh())})("rowSelect",function(e){C(l);let i=c();return y(i.onRowSelect(e))})("unRowSelect",function(e){C(l);let i=c();return y(i.onRowUnselect(e))}),s(4,"ui-button",6),h("click",function(){C(l);let e=c();return y(e.addCompany())}),m()(),s(5,"div",7)(6,"system-company-detail",8),h("refresh",function(){C(l);let e=c();return y(e.listCompany())})("remove",function(){C(l);let e=c();return y(e.onRemove())})("close",function(){C(l);let e=c();return y(e.onClose())}),m()()()}if(a&2){let l=c();n(2),r("useAdd",!1)("useRemove",!1)("cols",l.cols)("data",l.companyList)("dataKey","companyId")("selection",l.selection),n(2),r("size","small")("icon","pi-plus")("label","\uD68C\uC0AC\uC815\uBCF4 \uB4F1\uB85D")("outlined",!0),n(2),r("detail",l.detail)}}var Pe=(()=>{let o=class o extends ${constructor(t,e){super(),this.companyStore=t,this.companyService=e,this.detail=null,this.cols=[{field:"corporateName",header:"\uBC95\uC778\uBA85"},{field:"companyName",header:"\uD68C\uC0AC\uBA85"},{field:"registrationNo",header:"\uC0AC\uC5C5\uC790\uB4F1\uB85D\uBC88\uD638"},{field:"companyAddr",header:"\uD68C\uC0AC \uC18C\uC7AC\uC9C0"},{field:"ceoName",header:"\uB300\uD45C\uC790\uBA85"}]}get companyList(){return this.companyStore.select("companyList").value}get companyListDataLoad(){return this.companyStore.select("companyListDataLoad").value}ngOnInit(){!this.companyListDataLoad&&this.user&&this.listCompany()}listCompany(){this.companyService.listCompany()}addCompany(){this.detail={},this.splitter.show()}onRowSelect(t){this.companyService.getCompany$(t.data.companyId).subscribe(e=>{this.detail=e.company,this.splitter.show()})}onRowUnselect(t){this.detail={},this.splitter.hide()}onRefresh(){this.listCompany()}onRemove(){this.splitter.hide(),this.listCompany()}onClose(){this.splitter.hide()}};o.\u0275fac=function(e){return new(e||o)(f(Q),f(g))},o.\u0275cmp=v({type:o,selectors:[["view-system-company"]],viewQuery:function(e,i){if(e&1&&E(me,5),e&2){let u;B(u=T())&&(i.splitter=u.first)}},standalone:!0,features:[R,S],decls:9,vars:2,consts:[["splitter",""],["table",""],[1,"mt-5"],[3,"text"],[3,"refresh"],["first","",3,"refresh","rowSelect","unRowSelect","useAdd","useRemove","cols","data","dataKey","selection"],["buttons","",3,"click","size","icon","label","outlined"],["second",""],[3,"refresh","remove","close","detail"]],template:function(e,i){e&1&&(s(0,"layout-page-description")(1,"ul")(2,"li"),N(3,"\uD68C\uC0AC\uC815\uBCF4\uB97C \uC870\uD68C/\uC785\uB825\uD560 \uC218 \uC788\uC5B4\uC694."),m()()(),w(4,pe,3,0)(5,ce,7,11,"ui-splitter"),s(6,"div",2),p(7,"ui-content-title",3),s(8,"view-system-company-apply",4),h("refresh",function(){return i.listCompany()}),m()()),e&2&&(n(4),b(i.companyListDataLoad?5:4),n(3),r("text","\uD68C\uC0AC\uB4F1\uB85D\uC2E0\uCCAD\uAD00\uB9AC"))},dependencies:[I,L,U,G,x,P,Z,te]});let a=o;return a})();export{Pe as SystemCompanyComponent};
