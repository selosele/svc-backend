import{a as de}from"./chunk-6KVZPIBJ.js";import{b as ce}from"./chunk-ESXAWVCH.js";import{a as S,b as pe,c as Ce}from"./chunk-GZI5C7JE.js";import{F as ae,d as ee,e as te,f as ie,l as ne,n as oe,o as d,p as re,q as se,w as le,x as ue,y as me}from"./chunk-X3RQ7JMA.js";import{A as f,Da as B,Dc as J,E as M,Ec as K,K as r,L as _,Ob as O,T as L,Uc as W,V,Vb as D,Wb as y,X as s,Zb as Q,_b as z,aa as T,ba as A,c as C,ca as N,da as R,ea as l,fa as u,ga as m,gd as X,id as Z,ka as k,la as v,ma as c,qa as Y,ra as $,sa as j,tc as H,ua as q,v as g,vc as P,y as U,z as h,zc as G}from"./chunk-S74R4T3A.js";import"./chunk-M6OTSRMF.js";import"./chunk-FK6H3RFT.js";import{a as F,b as E,f as w}from"./chunk-USDYGGWM.js";var p=class extends Ce{};C([S(({value:n})=>y(n)?Number(n):null)],p.prototype,"originalMenuId",void 0);C([S(({value:n})=>y(n)?Number(n):null)],p.prototype,"menuId",void 0);C([S(({value:n})=>y(n)?Number(n):null)],p.prototype,"upMenuId",void 0);C([S(({value:n})=>y(n)?Number(n):null)],p.prototype,"menuOrder",void 0);C([S(({value:n})=>y(n)?Number(n):null)],p.prototype,"menuDepth",void 0);function fe(n,o){if(n&1&&m(0,"ui-checkbox",13),n&2){let t=o.$implicit,e=c();s("control",e.detailForm.get("menuRoleList"))("label",t.roleName)("value",t.roleId)}}var b=class b{constructor(o,t,e,i,a){this.fb=o,this.roleStore=t,this.messageService=e,this.codeService=i,this.menuService=a,this.detail=null,this.ynCodes=this.codeService.createYnCodeData(),this.roles=[],this.defaultRoles=[],this.defaultUseYn="Y",this.useRemove=!0,this.refresh=new M,this.remove=new M,this.close=new M}get isDetailNotEmpty(){return z(this.detail)}ngOnInit(){this.detailForm=this.fb.group({originalMenuId:[""],menuId:["",[d.numeric]],upMenuId:["",[d.numeric]],menuName:["",[d.required,d.maxLength(30)]],menuUrl:["",[d.required,d.maxLength(100)]],menuOrder:["",[d.numeric]],menuDepth:["",[d.required,d.numeric]],menuShowYn:["",[d.required]],useYn:["",[d.required]],menuRoleList:["",[d.required]]})}ngOnChanges(o){if(o.detail&&this.detailForm){if(this.useRemove=!0,this.roles=this.roleStore.select("roleList").value,this.defaultRoles=this.roles.filter(t=>t.roleId===O.EMPLOYEE.id).map(t=>t.roleId),Q(o.detail.currentValue)){this.useRemove=!1,this.detailForm.reset({useYn:this.defaultUseYn,menuRoleList:this.defaultRoles});return}this.detailForm.patchValue(E(F({},this.detail),{originalMenuId:this.detail.menuId,menuRoleList:this.detail.menuRoleList.map(t=>t.roleId)||this.defaultRoles}))}}onSubmit(o){return w(this,null,function*(){let t=D(o.originalMenuId)?"\uB4F1\uB85D":"\uC218\uC815";(yield this.messageService.confirm1(`\uBA54\uB274 \uC815\uBCF4\uB97C ${t}\uD558\uC2DC\uACA0\uC5B4\uC694?`))&&(D(o.originalMenuId)?this.menuService.addMenu$(o).subscribe(i=>{this.messageService.toastSuccess(`\uC815\uC0C1\uC801\uC73C\uB85C ${t}\uB418\uC5C8\uC5B4\uC694.`),this.detailForm.get("originalMenuId").patchValue(i.menu.menuId),this.refresh.emit()}):this.menuService.updateMenu$(o).subscribe(i=>{this.messageService.toastSuccess(`\uC815\uC0C1\uC801\uC73C\uB85C ${t}\uB418\uC5C8\uC5B4\uC694.`),this.refresh.emit()}))})}onRemove(o){return w(this,null,function*(){(yield this.messageService.confirm2("\uBA54\uB274\uB97C \uC0AD\uC81C\uD558\uC2DC\uACA0\uC5B4\uC694?<br>\uC774 \uC791\uC5C5\uC740 \uBCF5\uAD6C\uD560 \uC218 \uC5C6\uC5B4\uC694."))&&this.menuService.removeMenu$(this.detail.menuId).subscribe(()=>{this.messageService.toastSuccess("\uC815\uC0C1\uC801\uC73C\uB85C \uC0AD\uC81C\uB418\uC5C8\uC5B4\uC694."),this.remove.emit()})})}onClose(){this.close.emit()}};b.\u0275fac=function(t){return new(t||b)(_(W),_(de),_(Z),_(ce),_(te))},b.\u0275cmp=g({type:b,selectors:[["system-menu-detail"]],inputs:{detail:"detail"},outputs:{refresh:"refresh",remove:"remove",close:"close"},standalone:!0,features:[U,B],decls:28,vars:28,consts:[[3,"submit","remove","close","form","useRemove"],[3,"control"],[3,"text"],[1,"grid","mt-2","mb-4"],[1,"col-6"],[3,"control","label","placeholder","readonly"],[3,"control","label"],[1,"col-3"],[3,"control","label","placeholder"],[3,"control","label","data"],[1,"grid","mt-2"],[1,"col-12"],[3,"label"],[3,"control","label","value"]],template:function(t,e){t&1&&(l(0,"ui-split-form",0),v("submit",function(a){return e.onSubmit(a)})("remove",function(a){return e.onRemove(a)})("close",function(){return e.onClose()}),m(1,"ui-hidden-field",1)(2,"ui-content-title",2),l(3,"div",3)(4,"div",4),m(5,"ui-text-field",5),u(),l(6,"div",4),m(7,"ui-text-field",6),u(),l(8,"div",4),m(9,"ui-text-field",6),u(),l(10,"div",4),m(11,"ui-text-field",6),u(),l(12,"div",7),m(13,"ui-text-field",8),u(),l(14,"div",7),m(15,"ui-text-field",8),u(),l(16,"div",7),m(17,"ui-dropdown",9),u(),l(18,"div",7),m(19,"ui-dropdown",9),u()(),m(20,"ui-content-title",2),l(21,"div",10)(22,"div",11)(23,"ui-checkbox-group",12)(24,"ui-card")(25,"ui-checkbox-list"),N(26,fe,1,3,"ui-checkbox",13,A),u()()()()()()),t&2&&(s("form",e.detailForm)("useRemove",e.useRemove),r(),s("control",e.detailForm.get("originalMenuId")),r(),s("text","\uBA54\uB274 \uC815\uBCF4"),r(3),s("control",e.detailForm.get("menuId"))("label","\uBA54\uB274 ID")("placeholder","\uBE44\uC6CC\uB450\uC2DC\uBA74 \uC790\uB3D9\uC73C\uB85C \uC0DD\uC131\uB3FC\uC694.")("readonly",e.isDetailNotEmpty),r(2),s("control",e.detailForm.get("upMenuId"))("label","\uC0C1\uC704 \uBA54\uB274 ID"),r(2),s("control",e.detailForm.get("menuName"))("label","\uBA54\uB274\uBA85"),r(2),s("control",e.detailForm.get("menuUrl"))("label","\uBA54\uB274 URL"),r(2),s("control",e.detailForm.get("menuOrder"))("label","\uBA54\uB274 \uC21C\uC11C")("placeholder","\uC608) 1"),r(2),s("control",e.detailForm.get("menuDepth"))("label","\uBA54\uB274 \uB381\uC2A4")("placeholder","\uC608) 1"),r(2),s("control",e.detailForm.get("menuShowYn"))("label","\uD45C\uCD9C \uC5EC\uBD80")("data",e.ynCodes),r(2),s("control",e.detailForm.get("useYn"))("label","\uC0AC\uC6A9 \uC5EC\uBD80")("data",e.ynCodes),r(),s("text","\uBA54\uB274 \uAD8C\uD55C \uC815\uBCF4"),r(3),s("label","\uBA54\uB274 \uAD8C\uD55C"),r(3),R(e.roles))},dependencies:[re,ne,se,oe,ue,me,le,G,P]});var x=b;C([pe(p)],x.prototype,"onSubmit",null);var _e=["splitter"];function ve(n,o){n&1&&m(0,"ui-skeleton")(1,"ui-skeleton")(2,"ui-skeleton")}function ye(n,o){if(n&1){let t=k();l(0,"ui-splitter",null,0)(2,"ui-tree",1),v("refresh",function(){h(t);let i=c();return f(i.listMenu())})("nodeSelect",function(i){h(t);let a=c();return f(a.onNodeSelect(i))})("nodeUnselect",function(i){h(t);let a=c();return f(a.onNodeUnselect(i))}),l(3,"ui-button",2),v("click",function(){h(t);let i=c();return f(i.addMenu())}),u()(),l(4,"div",3)(5,"system-menu-detail",4),v("refresh",function(){h(t);let i=c();return f(i.listMenu())})("remove",function(){h(t);let i=c();return f(i.onRemove())})("close",function(){h(t);let i=c();return f(i.onClose())}),u()()()}if(n&2){let t=c();r(2),s("data",t.sysMenuTree),r(),s("size","small")("icon","pi-plus")("label","\uBA54\uB274 \uB4F1\uB85D")("outlined",!0),r(2),s("detail",t.detail)}}var Pe=(()=>{let o=class o extends ie{constructor(e){super(),this.menuStore=e,this.data=[],this.detail=null}get sysMenuTree(){return this.menuStore.select("sysMenuTree").value}get sysMenuListDataLoad(){return this.menuStore.select("sysMenuListDataLoad").value}ngOnInit(){!this.sysMenuListDataLoad&&this.user&&this.listMenu()}listMenu(){this.menuService.listSysMenu$().subscribe(e=>{this.menuService.listMenu(),this.menuStore.update("sysMenuListDataLoad",!0),this.menuStore.update("sysMenuTree",this.menuService.createSysMenuTree(e.menuList))})}onNodeSelect(e){this.menuService.getMenu$(+e.node.key).subscribe(i=>{this.detail=i.menu,this.splitter.show()})}onNodeUnselect(e){this.detail={},this.splitter.hide()}addMenu(){this.detail={},this.splitter.show()}onRemove(){this.splitter.hide(),this.listMenu()}onClose(){this.splitter.hide()}};o.\u0275fac=function(i){return new(i||o)(_(ee))},o.\u0275cmp=g({type:o,selectors:[["view-system-menu"]],viewQuery:function(i,a){if(i&1&&Y(_e,5),i&2){let I;$(I=j())&&(a.splitter=I.first)}},standalone:!0,features:[L,B],decls:6,vars:1,consts:[["splitter",""],["first","",3,"refresh","nodeSelect","nodeUnselect","data"],["buttons","",3,"click","size","icon","label","outlined"],["second",""],[3,"refresh","remove","close","detail"]],template:function(i,a){i&1&&(l(0,"layout-page-description")(1,"ul")(2,"li"),q(3,"\uBA54\uB274\uB97C \uC870\uD68C/\uC785\uB825\uD560 \uC218 \uC788\uC5B4\uC694."),u()()(),V(4,ve,3,0)(5,ye,6,6,"ui-splitter")),i&2&&(r(4),T(a.sysMenuListDataLoad?5:4))},dependencies:[J,X,K,H,ae,x]});let n=o;return n})();export{Pe as SystemMenuComponent};
