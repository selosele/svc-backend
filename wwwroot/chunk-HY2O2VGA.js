import{a as oe,b as w}from"./chunk-RNF5X5JX.js";import{a as I,b as re,c as ne}from"./chunk-GZI5C7JE.js";import{F as ie,f as J,l as W,n as X,o as a,p as Z,q as ee,r as te}from"./chunk-GGQPHCKP.js";import{$b as Q,A as p,Ac as Y,B as C,Ea as x,Ec as z,F,Fc as H,L as n,M as f,U as O,Vc as K,W as q,Wb as N,Xb as D,Y as s,_b as k,ba as A,c as _,fa as l,ga as d,ha as c,id as P,jd as G,la as $,ma as v,na as u,ra as B,sa as V,ta as E,uc as M,va as j,w as g,z as L}from"./chunk-D4IPV4YQ.js";import"./chunk-M6OTSRMF.js";import"./chunk-FK6H3RFT.js";import{a as U,b as R,f as T}from"./chunk-USDYGGWM.js";var h=class extends ne{};_([I(({value:r})=>D(r)?Number(r):null)],h.prototype,"codeOrder",void 0);_([I(({value:r})=>D(r)?Number(r):null)],h.prototype,"codeDepth",void 0);_([I(({value:r})=>D(r)?Number(r):null)],h.prototype,"userId",void 0);var y=class y{constructor(o,i,e){this.fb=o,this.messageService=i,this.codeService=e,this.detail=null,this.ynCodes=this.codeService.createYnCodeData(),this.useRemove=!0,this.refresh=new F,this.remove=new F,this.close=new F}get isDetailNotEmpty(){return Q(this.detail)}ngOnInit(){this.detailForm=this.fb.group({originalCodeId:[""],codeId:["",[a.required,a.maxLength(30)]],upCodeId:["",[a.maxLength(30)]],codeValue:["",[a.required,a.maxLength(10)]],codeName:["",[a.required,a.maxLength(100)]],codeContent:["",[a.maxLength(100)]],codeOrder:["",[a.numeric]],codeDepth:["",[a.required,a.numeric]],useYn:["",[a.required]]})}ngOnChanges(o){if(o.detail&&this.detailForm){if(this.useRemove=!0,k(o.detail.currentValue)){this.useRemove=!1,this.detailForm.reset();return}this.detailForm.patchValue(R(U({},this.detail),{originalCodeId:this.detail.codeId}))}}onSubmit(o){return T(this,null,function*(){let i=N(o.originalCodeId)?"\uB4F1\uB85D":"\uC218\uC815";(yield this.messageService.confirm1(`\uCF54\uB4DC \uC815\uBCF4\uB97C ${i}\uD558\uC2DC\uACA0\uC5B4\uC694?`))&&(N(o.originalCodeId)?this.codeService.addCode$(o).subscribe(t=>{this.messageService.toastSuccess(`\uC815\uC0C1\uC801\uC73C\uB85C ${i}\uB418\uC5C8\uC5B4\uC694.`),this.detailForm.get("originalCodeId").patchValue(t.code.codeId),this.refresh.emit()}):this.codeService.updateCode$(o).subscribe(t=>{this.messageService.toastSuccess(`\uC815\uC0C1\uC801\uC73C\uB85C ${i}\uB418\uC5C8\uC5B4\uC694.`),this.refresh.emit()}))})}onRemove(o){return T(this,null,function*(){(yield this.messageService.confirm2("\uCF54\uB4DC\uB97C \uC0AD\uC81C\uD558\uC2DC\uACA0\uC5B4\uC694?<br>\uC774 \uC791\uC5C5\uC740 \uBCF5\uAD6C\uD560 \uC218 \uC5C6\uC5B4\uC694."))&&this.codeService.removeCode$(this.detail.codeId).subscribe(()=>{this.messageService.toastSuccess("\uC815\uC0C1\uC801\uC73C\uB85C \uC0AD\uC81C\uB418\uC5C8\uC5B4\uC694."),this.remove.emit()})})}onClose(){this.close.emit()}};y.\u0275fac=function(i){return new(i||y)(f(K),f(G),f(w))},y.\u0275cmp=g({type:y,selectors:[["system-code-detail"]],inputs:{detail:"detail"},outputs:{refresh:"refresh",remove:"remove",close:"close"},standalone:!0,features:[L,x],decls:20,vars:24,consts:[[3,"submit","remove","close","form","useRemove"],[3,"control"],[3,"text"],[1,"grid","mt-2"],[1,"col-6"],[3,"control","label","readonly"],[3,"control","label"],[1,"col-12"],[1,"col-4"],[3,"control","label","placeholder"],[3,"control","label","data"]],template:function(i,e){i&1&&(l(0,"ui-split-form",0),v("submit",function(m){return e.onSubmit(m)})("remove",function(m){return e.onRemove(m)})("close",function(){return e.onClose()}),c(1,"ui-hidden-field",1)(2,"ui-content-title",2),l(3,"div",3)(4,"div",4),c(5,"ui-text-field",5),d(),l(6,"div",4),c(7,"ui-text-field",6),d(),l(8,"div",4),c(9,"ui-text-field",6),d(),l(10,"div",4),c(11,"ui-text-field",6),d(),l(12,"div",7),c(13,"ui-textarea",6),d(),l(14,"div",8),c(15,"ui-text-field",9),d(),l(16,"div",8),c(17,"ui-text-field",9),d(),l(18,"div",8),c(19,"ui-dropdown",10),d()()()),i&2&&(s("form",e.detailForm)("useRemove",e.useRemove),n(),s("control",e.detailForm.get("originalCodeId")),n(),s("text","\uCF54\uB4DC \uC815\uBCF4"),n(3),s("control",e.detailForm.get("codeId"))("label","\uCF54\uB4DC ID")("readonly",e.isDetailNotEmpty),n(2),s("control",e.detailForm.get("upCodeId"))("label","\uC0C1\uC704 \uCF54\uB4DC ID"),n(2),s("control",e.detailForm.get("codeValue"))("label","\uCF54\uB4DC \uAC12"),n(2),s("control",e.detailForm.get("codeName"))("label","\uCF54\uB4DC\uBA85"),n(2),s("control",e.detailForm.get("codeContent"))("label","\uCF54\uB4DC \uB0B4\uC6A9"),n(2),s("control",e.detailForm.get("codeOrder"))("label","\uCF54\uB4DC \uC21C\uC11C")("placeholder","\uC608) 1"),n(2),s("control",e.detailForm.get("codeDepth"))("label","\uCF54\uB4DC \uB381\uC2A4")("placeholder","\uC608) 1"),n(2),s("control",e.detailForm.get("useYn"))("label","\uC0AC\uC6A9 \uC5EC\uBD80")("data",e.ynCodes))},dependencies:[Z,W,te,X,ee,Y]});var S=y;_([re(h)],S.prototype,"onSubmit",null);var de=["treeTable"],ae=["splitter"];function me(r,o){r&1&&c(0,"ui-skeleton")(1,"ui-skeleton")(2,"ui-skeleton")}function ce(r,o){if(r&1){let i=$();l(0,"ui-splitter",null,0)(2,"ui-tree-table",2,1),v("refresh",function(){p(i);let t=u();return C(t.onRefresh())})("nodeSelect",function(t){p(i);let m=u();return C(m.onNodeSelect(t))})("nodeUnSelect",function(t){p(i);let m=u();return C(m.onNodeUnselect(t))}),l(4,"ui-button",3),v("click",function(){p(i);let t=u();return C(t.addCode())}),d()(),l(5,"div",4)(6,"system-code-detail",5),v("refresh",function(){p(i);let t=u();return C(t.listCode())})("remove",function(){p(i);let t=u();return C(t.onRemove())})("close",function(){p(i);let t=u();return C(t.onClose())}),d()()()}if(r&2){let i=u();n(2),s("useAdd",!1)("useRemove",!1)("cols",i.cols)("data",i.codeTree)("dataKey","codeId")("selection",i.selection),n(2),s("size","small")("icon","pi-plus")("label","\uCF54\uB4DC \uB4F1\uB85D")("outlined",!0),n(2),s("detail",i.detail)}}var Oe=(()=>{let o=class o extends J{constructor(e,t){super(),this.codeStore=e,this.codeService=t,this.detail=null,this.cols=[{field:"codeId",header:"\uCF54\uB4DC ID"},{field:"codeValue",header:"\uCF54\uB4DC \uAC12"},{field:"codeName",header:"\uCF54\uB4DC\uBA85"},{field:"codeOrder",header:"\uCF54\uB4DC \uC21C\uC11C"},{field:"useYn",header:"\uC0AC\uC6A9 \uC5EC\uBD80"}]}get codeTree(){return this.codeStore.select("codeTree").value}get codeListDataLoad(){return this.codeStore.select("codeListDataLoad").value}ngOnInit(){!this.codeListDataLoad&&this.user&&this.listCode()}listCode(){this.codeService.listCode$().subscribe(e=>{})}addCode(){this.detail={},this.splitter.show()}onNodeSelect(e){this.codeService.getCode$(e.node.data.codeId).subscribe(t=>{this.detail=t.code,this.splitter.show()})}onNodeUnselect(e){this.detail={},this.splitter.hide()}onRefresh(){this.listCode()}onRemove(){this.splitter.hide(),this.listCode()}onClose(){this.splitter.hide()}};o.\u0275fac=function(t){return new(t||o)(f(oe),f(w))},o.\u0275cmp=g({type:o,selectors:[["view-system-code"]],viewQuery:function(t,m){if(t&1&&(B(de,5),B(ae,5)),t&2){let b;V(b=E())&&(m.treeTable=b.first),V(b=E())&&(m.splitter=b.first)}},standalone:!0,features:[O,x],decls:6,vars:1,consts:[["splitter",""],["treeTable",""],["first","",3,"refresh","nodeSelect","nodeUnSelect","useAdd","useRemove","cols","data","dataKey","selection"],["buttons","",3,"click","size","icon","label","outlined"],["second",""],[3,"refresh","remove","close","detail"]],template:function(t,m){t&1&&(l(0,"layout-page-description")(1,"ul")(2,"li"),j(3,"\uCF54\uB4DC\uB97C \uC870\uD68C/\uC785\uB825\uD560 \uC218 \uC788\uC5B4\uC694."),d()()(),q(4,me,3,0)(5,ce,7,11,"ui-splitter")),t&2&&(n(4),A(m.codeListDataLoad?5:4))},dependencies:[z,P,H,M,ie,S]});let r=o;return r})();export{Oe as SystemCodeComponent};
