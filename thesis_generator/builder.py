# -*- coding: utf-8 -*-
import zipfile
import os
import html

def escape_xml(text):
    return html.escape(str(text))

def p(text="", bold=False, italic=False, size=26, color="1E293B", align="both", 
      space_before=0, space_after=120, line_spacing=312, bg=None, code_font=False, 
      page_break_before=False, style=None):
    
    align_xml = f'<w:jc w:val="{align}"/>' if align != "left" else ""
    shd_xml = f'<w:shd w:val="clear" w:color="auto" w:fill="{bg}"/>' if bg else ""
    rfont = '<w:rFonts w:ascii="Consolas" w:hAnsi="Consolas"/>' if code_font else '<w:rFonts w:ascii="Times New Roman" w:hAnsi="Times New Roman"/>'
    b_xml = '<w:b/>' if bold else ''
    i_xml = '<w:i/>' if italic else ''
    style_xml = f'<w:pStyle w:val="{style}"/>' if style else ''
    pb_xml = '<w:pageBreakBefore/>' if page_break_before else ''
    
    # Handle newlines
    lines = str(text).split("\n")
    runs_xml = ""
    for idx, l in enumerate(lines):
        if idx > 0:
            runs_xml += '<w:r><w:br/></w:r>'
        escaped = html.escape(l)
        runs_xml += f'''<w:r>
            <w:rPr>
                {rfont}
                {b_xml}
                {i_xml}
                <w:sz w:val="{size}"/>
                <w:szCs w:val="{size}"/>
                <w:color w:val="{color}"/>
            </w:rPr>
            <w:t xml:space="preserve">{escaped}</w:t>
        </w:r>'''
        
    return f'''<w:p>
        <w:pPr>
            {style_xml}
            {pb_xml}
            {align_xml}
            <w:spacing w:before="{space_before}" w:after="{space_after}" w:line="{line_spacing}" w:lineRule="auto"/>
            {shd_xml}
        </w:pPr>
        {runs_xml}
    </w:p>'''

def heading1(text, page_break_before=True):
    return f'''<w:p>
        <w:pPr>
            <w:pStyle w:val="Heading1"/>
            {'<w:pageBreakBefore/>' if page_break_before else ''}
            <w:jc w:val="left"/>
            <w:spacing w:before="360" w:after="160" w:line="312" w:lineRule="auto"/>
            <w:outlineLvl w:val="0"/>
        </w:pPr>
        <w:r>
            <w:rPr>
                <w:rFonts w:ascii="Times New Roman" w:hAnsi="Times New Roman"/>
                <w:b/>
                <w:sz w:val="32"/>
                <w:szCs w:val="32"/>
                <w:color w:val="1B365D"/>
            </w:rPr>
            <w:t xml:space="preserve">{html.escape(text)}</w:t>
        </w:r>
    </w:p>'''

def heading2(text):
    return f'''<w:p>
        <w:pPr>
            <w:pStyle w:val="Heading2"/>
            <w:jc w:val="left"/>
            <w:spacing w:before="240" w:after="120" w:line="312" w:lineRule="auto"/>
            <w:outlineLvl w:val="1"/>
        </w:pPr>
        <w:r>
            <w:rPr>
                <w:rFonts w:ascii="Times New Roman" w:hAnsi="Times New Roman"/>
                <w:b/>
                <w:sz w:val="28"/>
                <w:szCs w:val="28"/>
                <w:color w:val="0284C7"/>
            </w:rPr>
            <w:t xml:space="preserve">{html.escape(text)}</w:t>
        </w:r>
    </w:p>'''

def heading3(text):
    return f'''<w:p>
        <w:pPr>
            <w:pStyle w:val="Heading3"/>
            <w:jc w:val="left"/>
            <w:spacing w:before="180" w:after="90" w:line="312" w:lineRule="auto"/>
            <w:outlineLvl w:val="2"/>
        </w:pPr>
        <w:r>
            <w:rPr>
                <w:rFonts w:ascii="Times New Roman" w:hAnsi="Times New Roman"/>
                <w:b/>
                <w:sz w:val="26"/>
                <w:szCs w:val="26"/>
                <w:color w:val="0F172A"/>
            </w:rPr>
            <w:t xml:space="preserve">{html.escape(text)}</w:t>
        </w:r>
    </w:p>'''

def code_block(code_text):
    lines = code_text.strip().split("\n")
    runs_xml = ""
    for idx, l in enumerate(lines):
        if idx > 0:
            runs_xml += '<w:r><w:br/></w:r>'
        runs_xml += f'''<w:r>
            <w:rPr>
                <w:rFonts w:ascii="Consolas" w:hAnsi="Consolas"/>
                <w:sz w:val="20"/>
                <w:szCs w:val="20"/>
                <w:color w:val="0F172A"/>
            </w:rPr>
            <w:t xml:space="preserve">{html.escape(l)}</w:t>
        </w:r>'''
        
    return f'''<w:p>
        <w:pPr>
            <w:pBdr>
                <w:left w:val="single" w:sz="24" w:space="12" w:color="0284C7"/>
            </w:pBdr>
            <w:shd w:val="clear" w:color="auto" w:fill="F1F5F9"/>
            <w:spacing w:before="120" w:after="160" w:line="240" w:lineRule="auto"/>
            <w:ind w:left="240" w:right="140"/>
        </w:pPr>
        {runs_xml}
    </w:p>'''

def bullet(bold_prefix, text):
    escaped_bold = html.escape(bold_prefix)
    escaped_text = html.escape(text)
    return f'''<w:p>
        <w:pPr>
            <w:pStyle w:val="ListParagraph"/>
            <w:spacing w:before="40" w:after="80" w:line="300" w:lineRule="auto"/>
            <w:ind w:left="420" w:hanging="240"/>
        </w:pPr>
        <w:r>
            <w:rPr>
                <w:rFonts w:ascii="Times New Roman" w:hAnsi="Times New Roman"/>
                <w:b/>
                <w:sz w:val="26"/>
                <w:color w:val="0284C7"/>
            </w:rPr>
            <w:t xml:space="preserve">❖ </w:t>
        </w:r>
        <w:r>
            <w:rPr>
                <w:rFonts w:ascii="Times New Roman" w:hAnsi="Times New Roman"/>
                <w:b/>
                <w:sz w:val="26"/>
                <w:color w:val="0F172A"/>
            </w:rPr>
            <w:t xml:space="preserve">{escaped_bold} </w:t>
        </w:r>
        <w:r>
            <w:rPr>
                <w:rFonts w:ascii="Times New Roman" w:hAnsi="Times New Roman"/>
                <w:sz w:val="26"/>
                <w:color w:val="1E293B"/>
            </w:rPr>
            <w:t xml:space="preserve">{escaped_text}</w:t>
        </w:r>
    </w:p>'''

def note_box(title, text):
    return f'''<w:tbl>
        <w:tblPr>
            <w:tblW w:w="9360" w:type="dxa"/>
            <w:jc w:val="center"/>
            <w:tblBorders>
                <w:top w:val="single" w:sz="6" w:space="0" w:color="38BDF8"/>
                <w:left w:val="single" w:sz="36" w:space="0" w:color="0284C7"/>
                <w:bottom w:val="single" w:sz="6" w:space="0" w:color="38BDF8"/>
                <w:right w:val="single" w:sz="6" w:space="0" w:color="38BDF8"/>
            </w:tblBorders>
        </w:tblPr>
        <w:tblGrid><w:gridCol w:w="9360"/></w:tblGrid>
        <w:tr>
            <w:tc>
                <w:tcPr>
                    <w:tcW w:w="9360" w:type="dxa"/>
                    <w:shd w:val="clear" w:color="auto" w:fill="F0F9FF"/>
                    <w:tcMar>
                        <w:top w:w="140" w:type="dxa"/>
                        <w:bottom w:w="140" w:type="dxa"/>
                        <w:left w:w="200" w:type="dxa"/>
                        <w:right w:w="200" w:type="dxa"/>
                    </w:tcMar>
                </w:tcPr>
                {p(title, bold=True, size=24, color="0369A1", space_before=40, space_after=60)}
                {p(text, size=24, color="0C4A6E", space_before=0, space_after=40)}
            </w:tc>
        </w:tr>
    </w:tbl>
    {p("", space_after=120)}'''

def screenshot_placeholder(fig_num, fig_title, instruction="Nhấp chuột phải vào khung này -> Chọn 'Dán' (Paste) ảnh chụp thực tế hoặc Insert Picture (Kích thước chuẩn: 15cm x 8.5cm)"):
    return f'''<w:tbl>
        <w:tblPr>
            <w:tblW w:w="9360" w:type="dxa"/>
            <w:jc w:val="center"/>
            <w:tblBorders>
                <w:top w:val="dashed" w:sz="12" w:space="0" w:color="0284C7"/>
                <w:left w:val="dashed" w:sz="12" w:space="0" w:color="0284C7"/>
                <w:bottom w:val="dashed" w:sz="12" w:space="0" w:color="0284C7"/>
                <w:right w:val="dashed" w:sz="12" w:space="0" w:color="0284C7"/>
            </w:tblBorders>
        </w:tblPr>
        <w:tblGrid><w:gridCol w:w="9360"/></w:tblGrid>
        <w:tr>
            <w:trPr>
                <w:trHeight w:val="3800" w:hRule="atLeast"/>
            </w:trPr>
            <w:tc>
                <w:tcPr>
                    <w:tcW w:w="9360" w:type="dxa"/>
                    <w:shd w:val="clear" w:color="auto" w:fill="F8FAFC"/>
                    <w:vAlign w:val="center"/>
                    <w:tcMar>
                        <w:top w:w="200" w:type="dxa"/>
                        <w:bottom w:w="200" w:type="dxa"/>
                        <w:left w:w="200" w:type="dxa"/>
                        <w:right w:w="200" w:type="dxa"/>
                    </w:tcMar>
                </w:tcPr>
                {p("📷 [ Ô DÀNH ĐỂ CHÈN ẢNH CHỤP MÀN HÌNH CHỨC NĂNG ]", bold=True, size=26, color="1B365D", align="center", space_before=60, space_after=80)}
                {p(f"★ {fig_title} ★", bold=True, size=24, color="0284C7", align="center", space_before=0, space_after=80)}
                {p(instruction, italic=True, size=22, color="64748B", align="center", space_before=0, space_after=60)}
            </w:tc>
        </w:tr>
    </w:tbl>
    {p(f"Hình {fig_num}: {fig_title}", bold=True, italic=True, size=24, color="334155", align="center", space_before=80, space_after=180)}'''

def make_table(headers, rows, col_widths, header_bg="1B365D"):
    grid_xml = "".join([f'<w:gridCol w:w="{w}"/>' for w in col_widths])
    
    header_tr = '<w:tr><w:trPr><w:tblHeader/><w:cantSplit/></w:trPr>'
    for idx, h in enumerate(headers):
        w = col_widths[idx]
        header_tr += f'''<w:tc>
            <w:tcPr>
                <w:tcW w:w="{w}" w:type="dxa"/>
                <w:shd w:val="clear" w:color="auto" w:fill="{header_bg}"/>
                <w:vAlign w:val="center"/>
                <w:tcMar>
                    <w:top w:w="120" w:type="dxa"/>
                    <w:bottom w:w="120" w:type="dxa"/>
                    <w:left w:w="120" w:type="dxa"/>
                    <w:right w:w="120" w:type="dxa"/>
                </w:tcMar>
            </w:tcPr>
            {p(h, bold=True, size=22, color="FFFFFF", align="center", space_before=40, space_after=40)}
        </w:tc>'''
    header_tr += '</w:tr>'
    
    rows_tr = ""
    for r_idx, r in enumerate(rows):
        bg = "F8FAFC" if r_idx % 2 == 1 else "FFFFFF"
        rows_tr += '<w:tr><w:trPr><w:cantSplit/></w:trPr>'
        for c_idx, cell in enumerate(r):
            w = col_widths[c_idx]
            bold = (c_idx == 0 or "[x]" in cell or "Thành công" in cell or "COMMIT" in cell)
            color = "15803D" if ("[x]" in cell or "Thành công" in cell or "COMMIT" in cell) else ("DC2626" if "ROLLBACK" in cell or "Thất bại" in cell else "1E293B")
            align = "center" if (c_idx == 0 and len(cell) < 15) or "[x]" in cell or len(cell) <= 6 else "left"
            rows_tr += f'''<w:tc>
                <w:tcPr>
                    <w:tcW w:w="{w}" w:type="dxa"/>
                    <w:shd w:val="clear" w:color="auto" w:fill="{bg}"/>
                    <w:vAlign w:val="center"/>
                    <w:tcMar>
                        <w:top w:w="90" w:type="dxa"/>
                        <w:bottom w:w="90" w:type="dxa"/>
                        <w:left w:w="120" w:type="dxa"/>
                        <w:right w:w="120" w:type="dxa"/>
                    </w:tcMar>
                </w:tcPr>
                {p(cell, bold=bold, size=22, color=color, align=align, space_before=40, space_after=40)}
            </w:tc>'''
        rows_tr += '</w:tr>'
        
    return f'''<w:tbl>
        <w:tblPr>
            <w:tblW w:w="0" w:type="auto"/>
            <w:jc w:val="center"/>
            <w:tblBorders>
                <w:top w:val="single" w:sz="6" w:space="0" w:color="94A3B8"/>
                <w:bottom w:val="single" w:sz="6" w:space="0" w:color="94A3B8"/>
                <w:left w:val="single" w:sz="6" w:space="0" w:color="94A3B8"/>
                <w:right w:val="single" w:sz="6" w:space="0" w:color="94A3B8"/>
                <w:insideH w:val="single" w:sz="4" w:space="0" w:color="CBD5E1"/>
                <w:insideV w:val="single" w:sz="4" w:space="0" w:color="CBD5E1"/>
            </w:tblBorders>
        </w:tblPr>
        <w:tblGrid>{grid_xml}</w:tblGrid>
        {header_tr}
        {rows_tr}
    </w:tbl>
    {p("", space_after=120)}'''

def page_break():
    return '<w:p><w:r><w:br w:type="page"/></w:r></w:p>'

def build_docx_package(output_path, body_xml):
    content_types_xml = '''<?xml version="1.0" encoding="UTF-8" standalone="yes"?>
<Types xmlns="http://schemas.openxmlformats.org/package/2006/content-types">
    <Default Extension="rels" ContentType="application/vnd.openxmlformats-package.relationships+xml"/>
    <Default Extension="xml" ContentType="application/xml"/>
    <Override PartName="/word/document.xml" ContentType="application/vnd.openxmlformats-officedocument.wordprocessingml.document.main+xml"/>
    <Override PartName="/word/styles.xml" ContentType="application/vnd.openxmlformats-officedocument.wordprocessingml.styles+xml"/>
    <Override PartName="/word/header1.xml" ContentType="application/vnd.openxmlformats-officedocument.wordprocessingml.header+xml"/>
    <Override PartName="/word/footer1.xml" ContentType="application/vnd.openxmlformats-officedocument.wordprocessingml.footer+xml"/>
</Types>'''

    rels_xml = '''<?xml version="1.0" encoding="UTF-8" standalone="yes"?>
<Relationships xmlns="http://schemas.openxmlformats.org/package/2006/relationships">
    <Relationship Id="rId1" Type="http://schemas.openxmlformats.org/officeDocument/2006/relationships/officeDocument" Target="word/document.xml"/>
</Relationships>'''

    doc_rels_xml = '''<?xml version="1.0" encoding="UTF-8" standalone="yes"?>
<Relationships xmlns="http://schemas.openxmlformats.org/package/2006/relationships">
    <Relationship Id="rId1" Type="http://schemas.openxmlformats.org/officeDocument/2006/relationships/styles" Target="styles.xml"/>
    <Relationship Id="rId2" Type="http://schemas.openxmlformats.org/officeDocument/2006/relationships/header" Target="header1.xml"/>
    <Relationship Id="rId3" Type="http://schemas.openxmlformats.org/officeDocument/2006/relationships/footer" Target="footer1.xml"/>
</Relationships>'''

    header_xml = '''<?xml version="1.0" encoding="UTF-8" standalone="yes"?>
<w:hdr xmlns:w="http://schemas.openxmlformats.org/wordprocessingml/2006/main">
    <w:p>
        <w:pPr>
            <w:pBdr>
                <w:bottom w:val="single" w:sz="6" w:space="2" w:color="0284C7"/>
            </w:pBdr>
            <w:tabs>
                <w:tab w:val="right" w:pos="9360"/>
            </w:tabs>
            <w:spacing w:before="0" w:after="60"/>
        </w:pPr>
        <w:r>
            <w:rPr>
                <w:rFonts w:ascii="Times New Roman" w:hAnsi="Times New Roman"/>
                <w:i/>
                <w:sz w:val="18"/>
                <w:color w:val="475569"/>
            </w:rPr>
            <w:t>Trường Cao Đẳng Công Thương TP.HCM (HITC) - Đồ Án Môn Học C# .NET Core</w:t>
        </w:r>
        <w:r><w:tab/></w:r>
        <w:r>
            <w:rPr>
                <w:rFonts w:ascii="Times New Roman" w:hAnsi="Times New Roman"/>
                <w:i/>
                <w:b/>
                <w:sz w:val="18"/>
                <w:color w:val="0284C7"/>
            </w:rPr>
            <w:t>SVTH: Trần Hoàng Lin</w:t>
        </w:r>
    </w:p>
</w:hdr>'''

    footer_xml = '''<?xml version="1.0" encoding="UTF-8" standalone="yes"?>
<w:ftr xmlns:w="http://schemas.openxmlformats.org/wordprocessingml/2006/main">
    <w:p>
        <w:pPr>
            <w:pBdr>
                <w:top w:val="single" w:sz="4" w:space="2" w:color="CBD5E1"/>
            </w:pBdr>
            <w:tabs>
                <w:tab w:val="right" w:pos="9360"/>
            </w:tabs>
            <w:spacing w:before="60" w:after="0"/>
        </w:pPr>
        <w:r>
            <w:rPr>
                <w:rFonts w:ascii="Times New Roman" w:hAnsi="Times New Roman"/>
                <w:sz w:val="18"/>
                <w:color w:val="64748B"/>
            </w:rPr>
            <w:t>Ăn Vặt Store - Giải pháp Quản lý Kho &amp; POS Bán lẻ Hiện đại</w:t>
        </w:r>
        <w:r><w:tab/></w:r>
        <w:r>
            <w:rPr>
                <w:rFonts w:ascii="Times New Roman" w:hAnsi="Times New Roman"/>
                <w:sz w:val="18"/>
                <w:color w:val="64748B"/>
            </w:rPr>
            <w:t xml:space="preserve">Trang </w:t>
        </w:r>
        <w:fldSimple w:instr="PAGE">
            <w:r>
                <w:rPr>
                    <w:rFonts w:ascii="Times New Roman" w:hAnsi="Times New Roman"/>
                    <w:b/>
                    <w:sz w:val="18"/>
                    <w:color w:val="1E293B"/>
                </w:rPr>
                <w:t>1</w:t>
            </w:r>
        </w:fldSimple>
        <w:r>
            <w:rPr>
                <w:rFonts w:ascii="Times New Roman" w:hAnsi="Times New Roman"/>
                <w:sz w:val="18"/>
                <w:color w:val="64748B"/>
            </w:rPr>
            <w:t xml:space="preserve"> / </w:t>
        </w:r>
        <w:fldSimple w:instr="NUMPAGES">
            <w:r>
                <w:rPr>
                    <w:rFonts w:ascii="Times New Roman" w:hAnsi="Times New Roman"/>
                    <w:b/>
                    <w:sz w:val="18"/>
                    <w:color w:val="1E293B"/>
                </w:rPr>
                <w:t>80</w:t>
            </w:r>
        </w:fldSimple>
    </w:p>
</w:ftr>'''

    styles_xml = '''<?xml version="1.0" encoding="UTF-8" standalone="yes"?>
<w:styles xmlns:w="http://schemas.openxmlformats.org/wordprocessingml/2006/main">
    <w:docDefaults>
        <w:rPrDefault>
            <w:rPr>
                <w:rFonts w:ascii="Times New Roman" w:hAnsi="Times New Roman" w:eastAsia="Times New Roman" w:cs="Times New Roman"/>
                <w:sz w:val="26"/>
                <w:szCs w:val="26"/>
                <w:lang w:val="vi-VN"/>
            </w:rPr>
        </w:rPrDefault>
    </w:docDefaults>
    <w:style w:type="paragraph" w:default="1" w:styleId="Normal">
        <w:name w:val="Normal"/>
        <w:qFormat/>
    </w:style>
    <w:style w:type="paragraph" w:styleId="Heading1">
        <w:name w:val="heading 1"/>
        <w:basedOn w:val="Normal"/>
        <w:next w:val="Normal"/>
        <w:qFormat/>
        <w:pPr>
            <w:spacing w:before="360" w:after="160"/>
            <w:outlineLvl w:val="0"/>
        </w:pPr>
        <w:rPr>
            <w:rFonts w:ascii="Times New Roman" w:hAnsi="Times New Roman"/>
            <w:b/>
            <w:sz w:val="32"/>
            <w:szCs w:val="32"/>
            <w:color w:val="1B365D"/>
        </w:rPr>
    </w:style>
    <w:style w:type="paragraph" w:styleId="Heading2">
        <w:name w:val="heading 2"/>
        <w:basedOn w:val="Normal"/>
        <w:next w:val="Normal"/>
        <w:qFormat/>
        <w:pPr>
            <w:spacing w:before="240" w:after="120"/>
            <w:outlineLvl w:val="1"/>
        </w:pPr>
        <w:rPr>
            <w:rFonts w:ascii="Times New Roman" w:hAnsi="Times New Roman"/>
            <w:b/>
            <w:sz w:val="28"/>
            <w:szCs w:val="28"/>
            <w:color w:val="0284C7"/>
        </w:rPr>
    </w:style>
    <w:style w:type="paragraph" w:styleId="Heading3">
        <w:name w:val="heading 3"/>
        <w:basedOn w:val="Normal"/>
        <w:next w:val="Normal"/>
        <w:qFormat/>
        <w:pPr>
            <w:spacing w:before="180" w:after="90"/>
            <w:outlineLvl w:val="2"/>
        </w:pPr>
        <w:rPr>
            <w:rFonts w:ascii="Times New Roman" w:hAnsi="Times New Roman"/>
            <w:b/>
            <w:sz w:val="26"/>
            <w:szCs w:val="26"/>
            <w:color w:val="0F172A"/>
        </w:rPr>
    </w:style>
    <w:style w:type="paragraph" w:styleId="ListParagraph">
        <w:name w:val="List Paragraph"/>
        <w:basedOn w:val="Normal"/>
        <w:qFormat/>
    </w:style>
</w:styles>'''

    document_xml = f'''<?xml version="1.0" encoding="UTF-8" standalone="yes"?>
<w:document xmlns:w="http://schemas.openxmlformats.org/wordprocessingml/2006/main"
            xmlns:r="http://schemas.openxmlformats.org/officeDocument/2006/relationships">
    <w:body>
        {body_xml}
        <w:sectPr>
            <w:headerReference w:type="default" r:id="rId2"/>
            <w:footerReference w:type="default" r:id="rId3"/>
            <w:pgSz w:w="11906" w:h="16838"/>
            <w:pgMar w:top="1134" w:right="1134" w:bottom="1134" w:left="1701" w:header="720" w:footer="720" w:gutter="0"/>
        </w:sectPr>
    </w:body>
</w:document>'''

    with zipfile.ZipFile(output_path, 'w', zipfile.ZIP_DEFLATED) as zf:
        zf.writestr('[Content_Types].xml', content_types_xml)
        zf.writestr('_rels/.rels', rels_xml)
        zf.writestr('word/_rels/document.xml.rels', doc_rels_xml)
        zf.writestr('word/document.xml', document_xml)
        zf.writestr('word/styles.xml', styles_xml)
        zf.writestr('word/header1.xml', header_xml)
        zf.writestr('word/footer1.xml', footer_xml)

    print(f"Build Word document successful: {output_path}")
