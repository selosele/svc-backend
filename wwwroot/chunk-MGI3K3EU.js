import{a as K}from"./chunk-IBEPRFNH.js";import{a as F}from"./chunk-6KVZPIBJ.js";import{F as v,f as b,i as U}from"./chunk-X3RQ7JMA.js";import{A as D,Da as C,Dc as T,K as a,L as s,T as L,V as g,X as l,aa as I,ea as u,fa as d,fd as h,ga as c,h as R,hc as w,hd as x,ka as A,kc as B,la as _,ma as f,ua as p,v as m,z as y}from"./chunk-S74R4T3A.js";import"./chunk-M6OTSRMF.js";import"./chunk-FK6H3RFT.js";import"./chunk-USDYGGWM.js";var M=(()=>{let t=class t{constructor(i){this.config=i,this.userListcols=[{field:"userId",header:"\uC0AC\uC6A9\uC790 ID"},{field:"userAccount",header:"\uC0AC\uC6A9\uC790 \uACC4\uC815"},{field:"employeeName",header:"\uC9C1\uC6D0\uBA85"},{field:"companyName",header:"\uD68C\uC0AC\uBA85"},{field:"userActiveYn",header:"\uC0AC\uC6A9\uC790 \uD65C\uC131\uD654 \uC5EC\uBD80"},{field:"rolesString",header:"\uAD8C\uD55C"}],this.menuTreecols=[{field:"menuId",header:"\uBA54\uB274 ID"},{field:"menuName",header:"\uBA54\uB274\uBA85"},{field:"menuUrl",header:"\uBA54\uB274 URL"},{field:"menuDepth",header:"\uBA54\uB274 \uB381\uC2A4"},{field:"useYn",header:"\uC0AC\uC6A9\uC5EC\uBD80"}]}get userList(){return this.config.data.userList}get menuTree(){return this.config.data.menuTree}};t.\u0275fac=function(e){return new(e||t)(s(w))},t.\u0275cmp=m({type:t,selectors:[["modal-system-role-detail"]],standalone:!0,features:[C],decls:6,vars:14,consts:[[3,"title","useAdd","useRemove","useRefresh","cols","data","dataKey"]],template:function(e,r){e&1&&(u(0,"layout-page-description")(1,"ul")(2,"li"),p(3,"\uAD8C\uD55C\uBCC4 \uC0AC\uC6A9\uC790 \uBC0F \uBA54\uB274 \uBAA9\uB85D\uC744 \uC870\uD68C\uD560 \uC218 \uC788\uC5B4\uC694."),d()()(),c(4,"ui-table",0)(5,"ui-tree-table",0)),e&2&&(a(4),l("title","\uC0AC\uC6A9\uC790 \uBAA9\uB85D")("useAdd",!1)("useRemove",!1)("useRefresh",!1)("cols",r.userListcols)("data",r.userList)("dataKey","userId"),a(),l("title","\uBA54\uB274 \uBAA9\uB85D")("useAdd",!1)("useRemove",!1)("useRefresh",!1)("cols",r.menuTreecols)("data",r.menuTree)("dataKey","menuId"))},dependencies:[v,h,x]});let o=t;return o})();function N(o,t){o&1&&c(0,"ui-skeleton")(1,"ui-skeleton")(2,"ui-skeleton")}function V(o,t){if(o&1){let n=A();u(0,"ui-table",2,0),_("refresh",function(){y(n);let e=f();return D(e.onRefresh())})("rowSelect",function(e){y(n);let r=f();return D(r.onRowSelect(e))}),d()}if(o&2){let n=f();l("useAdd",!1)("useRemove",!1)("useRowIndex",!0)("cols",n.cols)("data",n.roleList)("dataKey","roleId")("selection",n.selection)}}var X=(()=>{let t=class t extends b{constructor(i,e,r,S){super(),this.roleStore=i,this.dialogService=e,this.userService=r,this.roleService=S,this.cols=[{field:"roleId",header:"\uAD8C\uD55C ID"},{field:"roleName",header:"\uAD8C\uD55C\uBA85"},{field:"roleOrder",header:"\uAD8C\uD55C \uC21C\uC11C"}]}get roleList(){return this.roleStore.select("roleList").value}get roleListDataLoad(){return this.roleStore.select("roleListDataLoad").value}ngOnInit(){!this.roleListDataLoad&&this.user&&this.listRole()}listRole(){this.roleService.listRole()}onRowSelect(i){R([this.userService.listUserByRole$({roleIdList:[i.data.roleId]}),this.menuService.listMenuByRole$({roleIdList:[i.data.roleId]})]).subscribe(([e,r])=>{let S=this.menuService.createMenuTree(r.menuList);this.dialogService.open(M,{focusOnShow:!1,header:`"${i.data.roleName}" \uAD8C\uD55C\uBCC4 \uC0AC\uC6A9\uC790 \uBC0F \uBA54\uB274 \uBAA9\uB85D \uC870\uD68C`,data:{userList:e,menuTree:S}})})}onRefresh(){this.listRole()}};t.\u0275fac=function(e){return new(e||t)(s(F),s(B),s(U),s(K))},t.\u0275cmp=m({type:t,selectors:[["view-system-role"]],standalone:!0,features:[L,C],decls:6,vars:1,consts:[["table",""],["first","",3,"useAdd","useRemove","useRowIndex","cols","data","dataKey","selection"],["first","",3,"refresh","rowSelect","useAdd","useRemove","useRowIndex","cols","data","dataKey","selection"]],template:function(e,r){e&1&&(u(0,"layout-page-description")(1,"ul")(2,"li"),p(3,"\uAD8C\uD55C\uC744 \uC870\uD68C\uD560 \uC218 \uC788\uC5B4\uC694."),d()()(),g(4,N,3,0)(5,V,2,7,"ui-table",1)),e&2&&(a(4),I(r.roleListDataLoad?5:4))},dependencies:[T,h,v]});let o=t;return o})();export{X as SystemRoleComponent};
