/*
* GMarkerEx Class, v1.0
*
* Copyright 2008 Masashi Katsumata (http://googlemaps.googlermania.com)
* 
* Licensed under the Apache License, Version 2.0 (the "License");
* you may not use this file except in compliance with the License.
* You may obtain a copy of the License at
* 
*       http://www.apache.org/licenses/LICENSE-2.0
*
* Unless required by applicable law or agreed to in writing, software
* distributed under the License is distributed on an "AS IS" BASIS,
* WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
* See the License for the specific language governing permissions and
* limitations under the License.
*
*/
/**
 * Constructor for GMarkerEx, which picks up on strings from the GMarker
 * options array, and then calls the GMarker constructor.
 *
 */

var GMarkerEx = function(latlng, options){
    this.latlng_ = latlng;
    this.title_ = options.title || "";
    if (options.title) {options.title = undefined;}
    this.opts_ = options;
    this.isIE_ = (navigator.userAgent.toLowerCase().indexOf('msie') != -1 ) ? true : false;
    
    //marker popup's matrix
    var yPos=0;
    this.popupImgSrc_="http://maps.google.com/mapfiles/transit/markers/1280.png";
    this.popupTbl=new Object();
    
    //left-top
    this.popupTbl["leftTop"]={ "left": 0, "top":yPos, "width":19, "height":7};
    this.popupTbl["leftTopFill"]={ "left": 16, "top":3, "width":4, "height":4};
    
    //right-top
    this.popupTbl["rightTop"]={ "left": 19, "top":yPos, "width":10, "height":7};
    this.popupTbl["rightTopImg"]={ "left": -125, "top":0, "width":10, "height":7};
    
    //center-top
    this.popupTbl["centerTopFill"]={ "left": 19, "top":yPos, "width":0, "height":7};
    
    //left-body
    yPos+=this.popupTbl["leftTop"].height;
    this.popupTbl["leftBody"]={ "left": 11, "top":yPos, "width":8, "height":0};
    
    //center-body
    this.popupTbl["centerBodyFill"]={ "left": 19, "top":yPos, "width": 40, "height":15};
    
    //right-body
    this.popupTbl["rightBody"]={ "left": 19, "top":yPos, "width":9, "height":0};
    
    //left-bottom
    this.popupTbl["leftBottom"]={ "left": 0, "top":yPos, "width":20, "height":21};
    this.popupTbl["leftBottomImg"]={ "left": 0, "top":-13, "width":20, "height":21};
    this.popupTbl["leftBottomFill"]={ "left": 16, "top":0, "width":4, "height":6};
    
    //right-bottom
    this.popupTbl["rightBottom"]={ "left": 19, "top":yPos, "width":10, "height":7};
    this.popupTbl["rightBottomImg"]={ "left": -125, "top":-13, "width":10, "height":7};

    //center-bottom
    this.popupTbl["centerBottomFill"]={ "left": 19, "top":(yPos + (this.isIE_ ? -1 : 0)), "width":0, "height":(6 + (this.isIE_ ? 1 : 0))};
    GMarker.apply(this, arguments);
};

GMarker.prototype.initialize_ = GMarker.prototype.initialize;
GMarker.prototype.redraw_ = GMarker.prototype.redraw;
GMarker.prototype.remove_ = GMarker.prototype.remove;

GMarkerEx.prototype = GMarker.prototype;

GMarkerEx.prototype.initialize = function(map) {

    function makeImgDiv(imgSrc, params){
        var isIE_ = (navigator.userAgent.toLowerCase().indexOf('msie') != -1 ) ? true : false;
        
        var imgDiv = document.createElement("div");
        with(imgDiv.style){
            position = "absolute";
            overflow="hidden";
            if(params.width){width = params.width+"px";};
            if(params.height){height = params.height+"px";};
        };
        
        var img = null;
        if(!isIE_){
            img = new Image();
            img.src = imgSrc;
        }else{
            img = document.createElement("div");
            with(img.style){
                if(params.width){width = params.width+"px";};
                if(params.height){height = params.height+"px";};
            };
        };
        with(img.style){
            position="relative";
            left = params.left+"px";
            top =  params.top+"px";
            filter="progid:DXImageTransform.Microsoft.AlphaImageLoader(src='"+imgSrc+"')";
        };
        imgDiv.appendChild(img);
        return imgDiv;
    };
    function fillDiv(params){
        
        var bgDiv = document.createElement("div");
        with(bgDiv.style){
            position="absolute";
            backgroundColor="#CCCCFF";
            fontSize="1px";
            lineHeight="1px";
            overflow="hidden";
            left = params.left+"px";
            top = params.top+"px";
            width = params.width+"px";
            height = params.height+"px";
        };
        return bgDiv;
    };
    
    GMarker.prototype.initialize_.apply(this, arguments);
    this.map_ = map;
    this.latlng_ = this.getLatLng();
    
    this.popupImg_ = new Image();
    this.popupImg_.src = "http://maps.google.com/mapfiles/transit/markers/1280.png";
    
    
    //====================================//
    //          make container            //
    //====================================//
    this.container_ = document.createElement("div");
    map.getPane(G_MAP_MARKER_PANE).appendChild(this.container_);
    with(this.container_.style){
        zIndex = GOverlay.getZIndex(this.latlng_.lat());
        position = "absolute";
        visibility = "hidden";
    };
    
    //====================================//
    //         left-top corner            //
    //====================================//
    this.leftTop_ = makeImgDiv(this.popupImgSrc_, this.popupTbl["leftTop"]);
    this.leftTop_.appendChild(fillDiv(this.popupTbl["leftTopFill"]));
    this.container_.appendChild(this.leftTop_);
    
    //====================================//
    //          left-body                 //
    //====================================//
    this.leftBody_ = fillDiv(this.popupTbl["leftBody"]);
    with(this.leftBody_.style){
        borderWidth="0 0 0 1px";
        borderStyle="none none none solid";
        borderColor="#000000";
    };
    this.container_.appendChild(this.leftBody_);
    
    
    //====================================//
    //   make container left-bottom side  //
    //====================================//
    this.leftBottom_ = makeImgDiv(this.popupImgSrc_, this.popupTbl["leftBottomImg"]);
    with(this.leftBottom_.style){
        left=this.popupTbl["leftBottom"].left+"px";
        top=this.popupTbl["leftBottom"].top+"px";
        width=this.popupTbl["leftBottom"].width+"px";
        height=this.popupTbl["leftBottom"].height+"px";
    };
    this.leftBottom_.appendChild(fillDiv(this.popupTbl["leftBottomFill"]));
    this.container_.appendChild(this.leftBottom_);
    
    //====================================//
    //          body container boddom           //
    //====================================//
    //make text container
    this.bodyContainer_  = document.createElement("div");
    with(this.bodyContainer_.style){
        position="absolute";
        backgroundColor="#CCCCFF";
        overflow="hidden";
        left = this.popupTbl["centerBodyFill"].left+"px";
        top = this.popupTbl["centerBodyFill"].top+"px";
        width = this.popupTbl["centerBodyFill"].width+"px";
        height = this.popupTbl["centerBodyFill"].height+"px";
    };
    this.container_.appendChild(this.bodyContainer_);
    
    //====================================//
    //             right-top              //
    //====================================//
    this.rightTop_ = makeImgDiv(this.popupImgSrc_, this.popupTbl["rightTopImg"]);
    with(this.rightTop_.style){
        left=this.popupTbl["rightTop"].left+"px";
        top=this.popupTbl["rightTop"].top+"px";
        width=this.popupTbl["rightTop"].width+"px";
        height=this.popupTbl["rightTop"].height+"px";
    };
    this.container_.appendChild(this.rightTop_);

    //====================================//
    //             right-bottom           //
    //====================================//
    this.rightBottom_ = makeImgDiv(this.popupImgSrc_, this.popupTbl["rightBottomImg"]);
    with(this.rightBottom_.style){
        left=this.popupTbl["rightBottom"].left+"px";
        top=this.popupTbl["rightBottom"].top+"px";
        width=this.popupTbl["rightBottom"].width+"px";
        height=this.popupTbl["rightBottom"].height+"px";
    };
    this.container_.appendChild(this.rightBottom_);

    
    //====================================//
    //          right-body                 //
    //====================================//
    this.rightBody_ = fillDiv(this.popupTbl["rightBody"]);
    with(this.rightBody_.style){
        borderWidth="0 1px 0 0";
        borderStyle="none solid none none";
        borderColor="#000000";
    };
    this.container_.appendChild(this.rightBody_);


    //====================================//
    //          body container bottom     //
    //====================================//
    this.centerBottom_ = fillDiv(this.popupTbl["centerBottomFill"]);
    with(this.centerBottom_.style){
        borderWidth="0 0 1px 0";
        borderStyle="none none solid none";
        borderColor="#000000";
    };
    this.container_.appendChild(this.centerBottom_);
    
    //====================================//
    //          body container top     //
    //====================================//
    this.centerTop_ = fillDiv(this.popupTbl["centerTopFill"]);
    with(this.centerTop_.style){
        borderColor="#000000";
        borderWidth="1px 0 0 0";
        borderStyle="solid none none none";
    };
    this.container_.appendChild(this.centerTop_);
    
    //====================================//
    //              events                //
    //====================================//
    var this_ = this;
    GEvent.addDomListener(this.container_, "mousedown", function(){return GEvent.trigger(this_, "mousedown");});
    GEvent.addDomListener(this.container_, "dragstart", function(){return GEvent.trigger(this_, "dragstart");});
    GEvent.addDomListener(this.container_, "mouseup", function(){return GEvent.trigger(this_, "mouseup");});
    GEvent.addDomListener(this.container_, "mouseover", function(){return GEvent.trigger(this_, "mouseover");});
    GEvent.addDomListener(this.container_, "mouseout", function(){return GEvent.trigger(this_, "mouseout");});
    
};

GMarkerEx.prototype.redraw = function(force){
    GMarker.prototype.redraw_.apply(this, arguments);
    
    if(force){
        this.setTitle(this.title_);
        this.latlng_=this.getLatLng();
        this.container_.style.zIndex = GOverlay.getZIndex(this.latlng_.lat());
    };
};

GMarkerEx.prototype.copy = function() {
    this.opts_.title = this.title_;
    return new GMarkerEx(this.latlng_, this.opts_);
};

GMarkerEx.prototype.showPopup = function(title){
    if(!this.isNull(title)){
        this.setTitle(title);
    };
    var info = this.map_.getInfoWindow();
    if(!info.isHidden() || this.isNull(this.title_)){
        return;
    };
    this.container_.style.visibility="visible";
};
GMarkerEx.prototype.hidePopup = function(){
    this.container_.style.visibility="hidden";
};


GMarkerEx.prototype.remove = function() {
    GEvent.clearInstanceListeners(this.container_);
    while(this.container_.firstChild){
        this.container_.removeChild(this.container_.firstChild);
    };
    this.container_.parentNode.removeChild(this.container_);
    GMarker.prototype.remove_.apply(this, arguments);
    delete arguments.callee;
};

GMarkerEx.prototype.setTitle = function(title) {
    this.title_ = title;
    while(this.bodyContainer_.firstChild){
        this.bodyContainer_.removeChild(this.bodyContainer_.firstChild);
    };
    this.bodyContainer_.innerHTML =title;
    if(!this.isIE_ && this.bodyContainer_.hasChildNodes){
        if(this.bodyContainer_.firstChild.nodeType==1){
            this.bodyContainer_.firstChild.style.margin = 0;
        };
    };
    var offsetBorder = this.isIE_ ? 2 : 0;
    var cSize  = this.getHtmlSize(title);
    var rightX = this.popupTbl["leftTop"].width + cSize.width;
    
    this.leftBottom_.style.top = (cSize.height +  this.popupTbl["leftBody"].top)+"px" ;
    this.leftBody_.style.height=cSize.height+"px";
    this.bodyContainer_.style.width = cSize.width+"px";
    this.bodyContainer_.style.height = cSize.height+"px";
    this.bodyContainer_.style.top = this.popupTbl["leftBody"].top;
    this.rightTop_.style.left=rightX+"px";
    this.rightBottom_.style.left=this.rightTop_.style.left;
    this.rightBottom_.style.top=this.leftBottom_.style.top;
    this.rightBody_.style.left=rightX +"px";
    this.rightBody_.style.height=this.leftBody_.style.height;
    this.centerBottom_.style.top =this.leftBottom_.style.top;
    this.centerBottom_.style.width = cSize.width+"px";
    this.centerTop_.style.width=cSize.width+"px";
    
    this.size_ = {"width":(rightX+ this.popupTbl["rightTop"].width), "height":(cSize.height + this.popupTbl["leftTop"].height + this.popupTbl["leftBottom"].height)};
    this.container_.style.width=this.size_.width+"px";
    this.container_.style.height=this.size_.height+"px";

    var pxPos = this.map_.fromLatLngToDivPixel(this.latlng_);
    this.container_.style.left =  pxPos.x+"px";
    this.container_.style.top = ( pxPos.y - this.size_.height) +"px";
};

GMarkerEx.prototype.getTitle = function() {
    return this.title_;
};

GMarkerEx.prototype.isNull = function(value) {
    if(!value && value!=0 ||
       value==undefined ||
       value=="" ||
       typeof value=="undefined"){return true;};
    return false;
};
GMarker.prototype.getHtmlSize = function(html) {
    var dummyTextNode = document.createElement("span");
    dummyTextNode.innerHTML = html;
    dummyTextNode.style.display="inline";
    document.body.appendChild(dummyTextNode);
    
    var elements = dummyTextNode.getElementsByTagName("*");
    var size = new Object();
    if(elements.length){
        var maxX = 0;
        var width = 6;  //margin
        var height = 6;  //margin
        for(var i=0;i<elements.length;i++){
            elements[i].style.display="inline";
            width=elements[i].offsetWidth;
            if(maxX<width){maxX = width;};
            height+=elements[i].offsetHeight;
        };
        size.width = dummyTextNode.offsetWidth;
        size.height = height;
    }else{
        size.width = dummyTextNode.offsetWidth;
        size.height = dummyTextNode.offsetHeight;
    };
    document.body.removeChild(dummyTextNode);
    return size;
};
