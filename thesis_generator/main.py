# -*- coding: utf-8 -*-
import os
import sys

# Ensure repository root is in sys.path
repo_root = os.path.dirname(os.path.dirname(os.path.abspath(__file__)))
if repo_root not in sys.path:
    sys.path.insert(0, repo_root)

from thesis_generator.builder import build_docx_package
from thesis_generator.frontmatter import get_frontmatter_xml
from thesis_generator.chapter1 import get_chapter1_xml
from thesis_generator.chapter2 import get_chapter2_xml
from thesis_generator.chapter3 import get_chapter3_xml
from thesis_generator.chapter4 import get_chapter4_xml
from thesis_generator.chapter5 import get_chapter5_xml
from thesis_generator.chapter6_and_backmatter import get_chapter6_xml

def generate_thesis_report(output_filename="Do_An_Mon_Hoc_Lap_Trinh_Ung_Dung_Csharp_NetCore.docx"):
    output_path = os.path.join(repo_root, output_filename)
    print(f"Bắt đầu tổng hợp nội dung thuyết minh đồ án...")
    
    xml_parts = []
    
    # 1. Trang bìa, Lời cam đoan, Lời cảm ơn, Phiếu đánh giá, Mục lục, Danh mục
    print("-> Đang tạo Phần đầu (Trang bìa, Lời cảm ơn, Phiếu đánh giá, Mục lục, Danh mục)...")
    xml_parts.append(get_frontmatter_xml())
    
    # 2. Chương 1: Tổng quan đề tài và Cơ sở lý thuyết nền tảng
    print("-> Đang tạo Chương 1: Tổng quan đề tài và Cơ sở lý thuyết nền tảng...")
    xml_parts.append(get_chapter1_xml())
    
    # 3. Chương 2: Phân tích yêu cầu và Thiết kế hệ thống
    print("-> Đang tạo Chương 2: Phân tích yêu cầu và Thiết kế hệ thống...")
    xml_parts.append(get_chapter2_xml())
    
    # 4. Chương 3: Triển khai phần Backend (ASP.NET Core Web API)
    print("-> Đang tạo Chương 3: Triển khai phần Backend (ASP.NET Core Web API)...")
    xml_parts.append(get_chapter3_xml())
    
    # 5. Chương 4: Triển khai phần Frontend Client (Windows Forms POS App)
    print("-> Đang tạo Chương 4: Triển khai phần Frontend Client (Windows Forms POS App)...")
    xml_parts.append(get_chapter4_xml())
    
    # 6. Chương 5: Kiểm thử hệ thống và Đánh giá kết quả đồ án
    print("-> Đang tạo Chương 5: Kiểm thử hệ thống và Đánh giá kết quả đồ án...")
    xml_parts.append(get_chapter5_xml())
    
    # 7. Chương 6: Kết luận và Hướng phát triển nâng cấp & Phụ lục
    print("-> Đang tạo Chương 6: Kết luận, Tài liệu tham khảo và Phụ lục kỹ thuật...")
    xml_parts.append(get_chapter6_xml())
    
    full_body_xml = "".join(xml_parts)
    print(f"Tổng dung lượng XML phần thân: {len(full_body_xml):,} ký tự.")
    
    # Đóng gói thành file docx chuẩn Microsoft Word
    build_docx_package(output_path, full_body_xml)
    print(f"Đã tạo thành công file Word đồ án tại: {output_path}")
    return output_path

if __name__ == "__main__":
    generate_thesis_report()
