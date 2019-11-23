window["jq$"] = jQuery.noConflict(true);
if (typeof window["jQuery"] == "undefined") {
    window["jQuery"] = window["jq$"];
}
if (typeof jigsaw != "undefined" || typeof window["$"] == "undefined") {
    window["$"] = window["jq$"];
}