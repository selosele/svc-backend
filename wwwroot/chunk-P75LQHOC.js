import{a as ye}from"./chunk-O7GJ7QMQ.js";import{b as fe}from"./chunk-ON2CIZOH.js";import{H as Ce,f as T,h as re,i as I,l as ne,m as le,n as se,o as c,p as ae,q as ue,r as me,s as de,w as ce,y as pe}from"./chunk-VXEORVKR.js";import{$b as J,A as C,Ac as X,B as y,Ea as k,Ec as Z,F,Fc as ee,Ka as M,L as n,M as _,Ma as P,Pb as G,U as E,Vc as te,W as h,Wb as V,Y as l,Yb as g,_b as K,ab as O,ba as f,bb as z,ca as R,da as L,ea as j,fa as a,ga as u,gd as ie,ha as m,jd as oe,kb as Q,la as x,ma as v,na as d,ra as $,sa as H,ta as q,uc as B,va as S,w as A,wc as W,xa as N,z as Y}from"./chunk-SI4ONGGJ.js";import"./chunk-M6OTSRMF.js";import"./chunk-FK6H3RFT.js";import{a as w,b as U,f as D}from"./chunk-USDYGGWM.js";function be(i,s){if(i&1&&(a(0,"p",2),S(1),M(2,"date"),u()),i&2){let o=d();n(),N("\uB9C8\uC9C0\uB9C9 \uB85C\uADF8\uC778 \uC77C\uC2DC: ",P(2,1,o.detailForm.get("lastLoginDt").value,"yyyy\uB144 MM\uC6D4 dd\uC77C hh\uC2DC mm\uBD84 ss\uCD08"),"")}}function De(i,s){if(i&1&&(a(0,"div",4),m(1,"ui-text-field",19),u()),i&2){let o=d();n(),l("control",o.detailForm.get("userId"))("label","\uC0AC\uC6A9\uC790 ID")("readonly",!0)}}function xe(i,s){if(i&1&&(a(0,"div",4),m(1,"ui-text-field",21),u()),i&2){let o=d();n(),l("control",o.detailForm.get("userPassword"))("label","\uC0AC\uC6A9\uC790 \uBE44\uBC00\uBC88\uD638")("type","password")("placeholder","12\uC790 \uC774\uB0B4")("autocomplete","new-password")}}function we(i,s){if(i&1){let o=x();a(0,"div",7)(1,"ui-button",22),v("click",function(t){C(o);let e=d();return y(e.updateUserActiveYn(t,(e.detail==null?null:e.detail.userActiveYn)==="Y"?"N":"Y"))}),S(2),u()()}if(i&2){let o=d();n(),l("severity","secondary"),n(),N(" ",(o.detail==null?null:o.detail.userActiveYn)==="Y"?"\uC7A0\uAE08\uC124\uC815":"\uC7A0\uAE08\uD574\uC81C"," ")}}function ge(i,s){if(i&1&&m(0,"ui-checkbox",10),i&2){let o=s.$implicit,r=d();l("control",r.detailForm.get("roles"))("label",o.roleName)("value",o.roleId)}}function Ue(i,s){if(i&1&&m(0,"ui-text-field",19),i&2){let o=d();l("control",o.detailForm.get("employee.workHistory.companyName"))("label","\uD68C\uC0AC\uBA85")("readonly",!0)}}function Ae(i,s){if(i&1&&m(0,"ui-company-field",17),i&2){let o=d();l("control",o.detailForm.get("employee.workHistory.companyName"))("label","\uD68C\uC0AC\uBA85")}}function Fe(i,s){if(i&1&&m(0,"ui-text-field",19),i&2){let o=d();l("control",o.detailForm.get("employee.workHistory.joinYmd"))("label","\uC785\uC0AC\uC77C\uC790")("readonly",!0)}}function Ee(i,s){if(i&1&&m(0,"ui-date-field",16),i&2){let o=d();l("control",o.detailForm.get("employee.workHistory.joinYmd"))("label","\uC785\uC0AC\uC77C\uC790")("dateFormat","yymmdd")("placeholder","YYYYMMDD")}}function ke(i,s){if(i&1&&m(0,"ui-text-field",19),i&2){let o=d();l("control",o.detailForm.get("employee.workHistory.quitYmd"))("label","\uD1F4\uC0AC\uC77C\uC790")("readonly",!0)}}function Be(i,s){if(i&1&&m(0,"ui-date-field",16),i&2){let o=d();l("control",o.detailForm.get("employee.workHistory.quitYmd"))("label","\uD1F4\uC0AC\uC77C\uC790")("dateFormat","yymmdd")("placeholder","YYYYMMDD")}}function Te(i,s){if(i&1){let o=x();a(0,"ui-button",23),v("click",function(){C(o);let t=d();return y(t.superLogin())}),S(1," \uB85C\uADF8\uC778 "),u()}i&2&&l("size","small")}function Ie(i,s){if(i&1){let o=x();a(0,"ui-button",23),v("click",function(){C(o);let t=d();return y(t.resetPassword())}),S(1," \uBE44\uBC00\uBC88\uD638 \uCD08\uAE30\uD654 "),u()}i&2&&l("size","small")}var he=(()=>{let s=class s extends T{constructor(r,t,e,p,b,_e){super(),this.fb=r,this.route=t,this.roleStore=e,this.messageService=p,this.userService=b,this.codeService=_e,this.detail=null,this.ynCodes=this.codeService.createYnCodeData(),this.defaultUserActiveYn="Y",this.roles=[],this.defaultRoles=[],this.useRemove=!0,this.isUserSelf=!1,this.refresh=new F,this.remove=new F,this.close=new F}get isDetailNotEmpty(){return J(this.detail)}ngOnInit(){this.route.data.subscribe(({code:r})=>{this.genderCodes=r.GENDER_00,this.rankCodes=r.RANK_00,this.jobTitleCodes=r.JOB_TITLE_00}),this.detailForm=this.fb.group({userId:[""],userAccount:["",[c.required,c.minLength(3),c.maxLength(20)]],userPassword:["",[c.required]],userActiveYn:["",[c.required]],lastLoginDt:[""],roles:["",[c.required]],employee:this.fb.group({employeeId:[""],employeeName:["",[c.required,c.maxLength(30)]],genderCode:["",[c.required]],birthYmd:[""],phoneNo:[""],emailAddr:["",[c.email]],workHistory:this.fb.group({workHistoryId:[""],companyId:[""],corporateName:["",[c.required]],companyName:["",[c.required]],joinYmd:["",[c.required]],quitYmd:[""],rankCode:["",[c.required]],jobTitleCode:["",[c.required]]})})})}ngOnChanges(r){if(r.detail&&this.detailForm){if(this.isUserSelf=Number(this.user?.userId)===this.detail.userId,this.useRemove=!this.isUserSelf,this.roles=this.roleStore.select("roleList").value,this.defaultRoles=this.roles.filter(t=>t.roleId===G.EMPLOYEE.id).map(t=>t.roleId),K(r.detail.currentValue)){this.useRemove=!1,this.detailForm.reset({userActiveYn:this.defaultUserActiveYn,roles:this.defaultRoles,employee:{workHistory:{jobTitleCode:"0098"}}}),this.detailForm.get("userPassword").setValidators([c.required,c.maxLength(12)]),this.detailForm.get("userPassword").updateValueAndValidity();return}this.detailForm.get("userPassword").clearValidators(),this.detailForm.get("userPassword").patchValue(null),this.detailForm.get("userPassword").updateValueAndValidity(),this.detailForm.patchValue(U(w({},this.detail),{roles:this.detail?.roles?.map(t=>t.roleId)||this.defaultRoles,employee:U(w({},this.detail?.employee),{workHistory:this.detail?.employee?.workHistoryList[0]})}))}}updateUserActiveYn(r,t){return D(this,null,function*(){(yield this.messageService.confirm1(`\uACC4\uC815\uC744 ${t==="Y"?"\uC7A0\uAE08\uD574\uC81C\uD558\uC2DC\uACA0\uC5B4\uC694?":"\uC7A0\uADF8\uC2DC\uACA0\uC5B4\uC694?"}`))&&this.userService.updateUser$({userId:this.detail?.userId,userActiveYn:t}).subscribe(p=>{this.messageService.toastSuccess("\uC815\uC0C1\uC801\uC73C\uB85C \uCC98\uB9AC\uB418\uC5C8\uC5B4\uC694."),this.detail=p.user,this.detailForm.patchValue(U(w(w({},this.detailForm.value),this.detail),{roles:this.detail?.roles?.map(b=>b.roleId)})),this.refresh.emit()})})}onSubmit(r){return D(this,null,function*(){let t=V(r.userId)?"\uB4F1\uB85D":"\uC218\uC815";(yield this.messageService.confirm1(`\uC0AC\uC6A9\uC790 \uBC0F \uC9C1\uC6D0 \uC815\uBCF4\uB97C ${t}\uD558\uC2DC\uACA0\uC5B4\uC694?`))&&(V(r.userId)?this.userService.addUser$(r).subscribe(p=>{this.messageService.toastSuccess(`\uC815\uC0C1\uC801\uC73C\uB85C ${t}\uB418\uC5C8\uC5B4\uC694.`),this.detailForm.get("userId").patchValue(p.user.userId),this.refresh.emit()}):this.userService.updateUser$(r).subscribe(p=>{this.messageService.toastSuccess(`\uC815\uC0C1\uC801\uC73C\uB85C ${t}\uB418\uC5C8\uC5B4\uC694.`),this.refresh.emit()}))})}onRemove(r){return D(this,null,function*(){(yield this.messageService.confirm2("\uC0AC\uC6A9\uC790\uB97C \uC0AD\uC81C\uD558\uC2DC\uACA0\uC5B4\uC694?<br>\uC774 \uC791\uC5C5\uC740 \uBCF5\uAD6C\uD560 \uC218 \uC5C6\uC5B4\uC694."))&&this.userService.removeUser$(this.detail.userId).subscribe(()=>{this.messageService.toastSuccess("\uC815\uC0C1\uC801\uC73C\uB85C \uC0AD\uC81C\uB418\uC5C8\uC5B4\uC694."),this.remove.emit()})})}superLogin(){return D(this,null,function*(){(yield this.messageService.confirm1(`${this.detail.userAccount}(${this.detail.employee.employeeName}\uB2D8) \uACC4\uC815\uC73C\uB85C \uB85C\uADF8\uC778\uD558\uC2DC\uACA0\uC5B4\uC694?`))&&this.authService.superLogin({userAccount:this.detail.userAccount})})}resetPassword(){return D(this,null,function*(){if(g(this.detail.employee.emailAddr)){this.messageService.toastInfo("\uC774\uBA54\uC77C\uC8FC\uC18C\uAC00 \uB4F1\uB85D\uB418\uC5B4 \uC788\uC9C0 \uC54A\uC544\uC694.<br>\uC774\uBA54\uC77C\uC8FC\uC18C\uB97C \uB4F1\uB85D\uD55C \uD6C4 \uB2E4\uC2DC \uC2DC\uB3C4\uD574\uC8FC\uC138\uC694.");return}(yield this.messageService.confirm1(`\uC784\uC2DC \uBE44\uBC00\uBC88\uD638\uB97C ${this.detail.userAccount}(${this.detail.employee.employeeName}\uB2D8) \uBA54\uC77C\uB85C \uBC1C\uC1A1\uD558\uC2DC\uACA0\uC5B4\uC694?`))&&this.authService.resetUserPassword$({userAccount:this.detail.userAccount,emailAddr:this.detail.employee.emailAddr}).subscribe(()=>{this.messageService.toastSuccess(`\uC784\uC2DC \uBE44\uBC00\uBC88\uD638\uB97C ${this.detail.userAccount}(${this.detail.employee.employeeName}\uB2D8) \uBA54\uC77C\uB85C \uBC1C\uC1A1\uD588\uC5B4\uC694.`)})})}onClose(){this.close.emit()}};s.\u0275fac=function(t){return new(t||s)(_(te),_(Q),_(ye),_(oe),_(I),_(fe))},s.\u0275cmp=A({type:s,selectors:[["system-user-detail"]],inputs:{detail:"detail"},outputs:{refresh:"refresh",remove:"remove",close:"close"},standalone:!0,features:[E,Y,k],decls:46,vars:45,consts:[[3,"submit","remove","close","form","useRemove"],[3,"text"],[1,"mt-2"],[1,"grid","mt-2","mb-4"],[1,"col-12","sm:col"],[3,"control","label","readonly","placeholder"],[3,"control","label","data","readonly"],[1,"col-12","sm:col","flex","align-items-end"],[1,"col-12"],[3,"label"],[3,"control","label","value"],[1,"grid","mt-2"],[1,"col-12","sm:col-3"],[3,"control","label","placeholder"],[3,"control","label","data"],[1,"col-12","sm:col-4"],[3,"control","label","dateFormat","placeholder"],[3,"control","label"],[3,"control"],[3,"control","label","readonly"],["button","",3,"size"],[3,"control","label","type","placeholder","autocomplete"],["button","",3,"click","severity"],["button","",3,"click","size"]],template:function(t,e){t&1&&(a(0,"ui-split-form",0),v("submit",function(b){return e.onSubmit(b)})("remove",function(b){return e.onRemove(b)})("close",function(){return e.onClose()}),m(1,"ui-content-title",1),h(2,be,3,4,"p",2),a(3,"div",3),h(4,De,2,3,"div",4),a(5,"div",4),m(6,"ui-text-field",5),u(),h(7,xe,2,5,"div",4),a(8,"div",4),m(9,"ui-dropdown",6),u(),h(10,we,3,2,"div",7),a(11,"div",8)(12,"ui-checkbox-group",9)(13,"ui-card")(14,"ui-checkbox-list"),L(15,ge,1,3,"ui-checkbox",10,R),u()()()()(),m(17,"ui-content-title",1),a(18,"div",11)(19,"div",12),m(20,"ui-text-field",13),u(),a(21,"div",12),m(22,"ui-dropdown",14),u(),a(23,"div",12),m(24,"ui-dropdown",14),u(),a(25,"div",12),m(26,"ui-dropdown",14),u(),a(27,"div",15),m(28,"ui-date-field",16),u(),a(29,"div",15),m(30,"ui-text-field",13),u(),a(31,"div",15),m(32,"ui-text-field",17),u(),a(33,"div",15),m(34,"ui-hidden-field",18)(35,"ui-hidden-field",18),h(36,Ue,1,3,"ui-text-field",19)(37,Ae,1,2,"ui-company-field",17),u(),a(38,"div",15),h(39,Fe,1,3,"ui-text-field",19)(40,Ee,1,4,"ui-date-field",16),u(),a(41,"div",15),h(42,ke,1,3,"ui-text-field",19)(43,Be,1,4,"ui-date-field",16),u()(),h(44,Te,2,1,"ui-button",20)(45,Ie,2,1,"ui-button",20),u()),t&2&&(l("form",e.detailForm)("useRemove",e.useRemove),n(),l("text","\uC0AC\uC6A9\uC790 \uC815\uBCF4"),n(),f(e.isDetailNotEmpty?2:-1),n(2),f(e.isDetailNotEmpty?4:-1),n(2),l("control",e.detailForm.get("userAccount"))("label","\uC0AC\uC6A9\uC790 \uACC4\uC815")("readonly",e.isDetailNotEmpty)("placeholder","20\uC790 \uC774\uB0B4"),n(),f(e.isDetailNotEmpty?-1:7),n(2),l("control",e.detailForm.get("userActiveYn"))("label","\uC0AC\uC6A9\uC790 \uACC4\uC815 \uD65C\uC131\uD654")("data",e.ynCodes)("readonly",e.isDetailNotEmpty),n(),f(e.isDetailNotEmpty&&!e.isUserSelf?10:-1),n(2),l("label","\uC0AC\uC6A9\uC790 \uAD8C\uD55C"),n(3),j(e.roles),n(2),l("text","\uC9C1\uC6D0 \uC815\uBCF4"),n(3),l("control",e.detailForm.get("employee.employeeName"))("label","\uC9C1\uC6D0\uBA85")("placeholder","30\uC790 \uC774\uB0B4"),n(2),l("control",e.detailForm.get("employee.genderCode"))("label","\uC131\uBCC4")("data",e.genderCodes),n(2),l("control",e.detailForm.get("employee.workHistory.rankCode"))("label","\uC9C1\uC704")("data",e.rankCodes),n(2),l("control",e.detailForm.get("employee.workHistory.jobTitleCode"))("label","\uC9C1\uCC45")("data",e.jobTitleCodes),n(2),l("control",e.detailForm.get("employee.birthYmd"))("label","\uC0DD\uB144\uC6D4\uC77C")("dateFormat","yymmdd")("placeholder","YYYYMMDD"),n(2),l("control",e.detailForm.get("employee.phoneNo"))("label","\uD734\uB300\uD3F0\uBC88\uD638")("placeholder","- \uC81C\uC678"),n(2),l("control",e.detailForm.get("employee.emailAddr"))("label","\uC774\uBA54\uC77C\uC8FC\uC18C"),n(2),l("control",e.detailForm.get("employee.workHistory.workHistoryId")),n(),l("control",e.detailForm.get("employee.workHistory.companyId")),n(),f(e.isDetailNotEmpty?36:37),n(3),f(e.isDetailNotEmpty?39:40),n(3),f(e.isDetailNotEmpty?42:43),n(2),f(e.isDetailNotEmpty&&!e.isUserSelf?44:-1),n(),f(e.isDetailNotEmpty?45:-1))},dependencies:[z,O,ae,ne,ue,de,me,se,le,ce,B,pe,X,W]});let i=s;return i})();var Ne=["splitter"];function Ve(i,s){i&1&&m(0,"ui-skeleton")(1,"ui-skeleton")(2,"ui-skeleton")}function Ye(i,s){if(i&1){let o=x();a(0,"ui-splitter",null,0)(2,"ui-table",2,1),v("refresh",function(){C(o);let t=d();return y(t.onRefresh())})("rowSelect",function(t){C(o);let e=d();return y(e.onRowSelect(t))})("unRowSelect",function(t){C(o);let e=d();return y(e.onRowUnselect(t))}),a(4,"ui-button",3),v("click",function(){C(o);let t=d();return y(t.addUser())}),u()(),a(5,"div",4)(6,"system-user-detail",5),v("refresh",function(){C(o);let t=d();return y(t.listUser())})("remove",function(){C(o);let t=d();return y(t.onRemove())})("close",function(){C(o);let t=d();return y(t.onClose())}),u()()()}if(i&2){let o=d();n(2),l("useAdd",!1)("useRemove",!1)("cols",o.cols)("data",o.userList)("dataKey","userId")("selection",o.selection),n(2),l("size","small")("icon","pi-plus")("label","\uC0AC\uC6A9\uC790 \uB4F1\uB85D")("outlined",!0),n(2),l("detail",o.detail)}}var lt=(()=>{let s=class s extends T{constructor(r,t){super(),this.userStore=r,this.userService=t,this.detail=null,this.cols=[{field:"userAccount",header:"\uC0AC\uC6A9\uC790 \uACC4\uC815"},{field:"employeeName",header:"\uC9C1\uC6D0\uBA85"},{field:"companyName",header:"\uD68C\uC0AC\uBA85"},{header:"\uC9C1\uC704/\uC9C1\uCC45",valueGetter:e=>e.jobTitleCode==="ETC"?e.rankCodeName:g(e.rankCodeName)&&g(e.jobTitleCodeName)?"":`${e.rankCodeName}/${e.jobTitleCodeName}`},{field:"userActiveYn",header:"\uC0AC\uC6A9\uC790 \uD65C\uC131\uD654 \uC5EC\uBD80"},{field:"rolesString",header:"\uAD8C\uD55C"}]}get userList(){return this.userStore.select("userList").value}get userListDataLoad(){return this.userStore.select("userListDataLoad").value}ngOnInit(){!this.userListDataLoad&&this.user&&this.listUser()}listUser(){this.userService.listUser()}addUser(){this.detail={},this.splitter.show()}onRowSelect(r){this.userService.getUser$(r.data.userId).subscribe(t=>{this.detail=t.user,this.splitter.show()})}onRowUnselect(r){this.detail={},this.splitter.hide()}onRefresh(){this.listUser()}onRemove(){this.splitter.hide(),this.listUser()}onClose(){this.splitter.hide()}};s.\u0275fac=function(t){return new(t||s)(_(re),_(I))},s.\u0275cmp=A({type:s,selectors:[["view-system-user"]],viewQuery:function(t,e){if(t&1&&$(Ne,5),t&2){let p;H(p=q())&&(e.splitter=p.first)}},standalone:!0,features:[E,k],decls:8,vars:1,consts:[["splitter",""],["table",""],["first","",3,"refresh","rowSelect","unRowSelect","useAdd","useRemove","cols","data","dataKey","selection"],["buttons","",3,"click","size","icon","label","outlined"],["second",""],[3,"refresh","remove","close","detail"]],template:function(t,e){t&1&&(a(0,"layout-page-description")(1,"ul")(2,"li"),S(3,"\uC0AC\uC6A9\uC790\uB97C \uC870\uD68C/\uC785\uB825\uD560 \uC218 \uC788\uC5B4\uC694."),u(),a(4,"li"),S(5,"\uC0AC\uC6A9\uC790\uC5D0\uAC8C \uAD8C\uD55C\uC744 \uBD80\uC5EC/\uD68C\uC218\uD560 \uC218 \uC788\uC5B4\uC694."),u()()(),h(6,Ve,3,0)(7,Ye,7,11,"ui-splitter")),t&2&&(n(6),f(e.userListDataLoad?7:6))},dependencies:[B,Z,ie,ee,Ce,he]});let i=s;return i})();export{lt as SystemUserComponent};
