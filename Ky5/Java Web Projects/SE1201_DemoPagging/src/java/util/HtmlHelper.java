package util;
public class HtmlHelper {

    public static String generateHyperlink(String href, String innerText) {
        return "<a id=\"paging\" href=\"" + href + "\" >" + innerText + "</a>";
    }

    public static String pagger(int pageIndex, int gap, int totalPage) {
        String result = "";
        if (pageIndex > gap) {
            result += generateHyperlink("list?page=1", "First    ");
        }

        for (int i = Math.max(pageIndex - gap, 1); i < pageIndex; i++) {
            result += generateHyperlink("list?page=" + i, "    " + i);
        }

        result += "<span class='pageindex'>" + "    " + pageIndex + "    " + "</span>";

        for (int i = pageIndex + 1; i < Math.min(pageIndex + gap, totalPage); i++) {
            result += generateHyperlink("list?page=" + i, "    " + i);
        }

        if (pageIndex < totalPage - gap) {
            result += generateHyperlink("list?page=" + totalPage, "    Last    ");
        }

        return result;
    }
}
