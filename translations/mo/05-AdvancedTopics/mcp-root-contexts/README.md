<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "e1cbc99fa7185139ad6d539eca09a2b3",
  "translation_date": "2025-06-02T20:22:40+00:00",
  "source_file": "05-AdvancedTopics/mcp-root-contexts/README.md",
  "language_code": "mo"
}
-->
## ตัวอย่าง: การใช้งาน Root Context สำหรับการวิเคราะห์การเงิน

ในตัวอย่างนี้ เราจะสร้าง root context สำหรับเซสชันการวิเคราะห์การเงิน โดยแสดงให้เห็นวิธีการรักษาสถานะในหลาย ๆ การโต้ตอบ

## ตัวอย่าง: การจัดการ Root Context

การจัดการ root context อย่างมีประสิทธิภาพเป็นสิ่งสำคัญสำหรับการรักษาประวัติการสนทนาและสถานะ ด้านล่างนี้คือตัวอย่างวิธีการใช้งานการจัดการ root context

## Root Context สำหรับการช่วยเหลือแบบหลายรอบ

ในตัวอย่างนี้ เราจะสร้าง root context สำหรับเซสชันการช่วยเหลือแบบหลายรอบ โดยแสดงวิธีการรักษาสถานะในหลาย ๆ การโต้ตอบ

## แนวทางปฏิบัติที่ดีที่สุดสำหรับ Root Context

นี่คือแนวทางปฏิบัติที่ดีที่สุดสำหรับการจัดการ root context อย่างมีประสิทธิภาพ:

- **สร้าง Context ที่เน้นเฉพาะเจาะจง**: สร้าง root context แยกตามวัตถุประสงค์หรือโดเมนของการสนทนา เพื่อรักษาความชัดเจน

- **ตั้งนโยบายหมดอายุ**: นำนโยบายมาใช้สำหรับการเก็บถาวรหรือลบ context เก่า เพื่อจัดการพื้นที่เก็บข้อมูลและปฏิบัติตามนโยบายการเก็บข้อมูล

- **จัดเก็บ Metadata ที่เกี่ยวข้อง**: ใช้ metadata ของ context เพื่อเก็บข้อมูลสำคัญเกี่ยวกับการสนทนาที่อาจมีประโยชน์ในภายหลัง

- **ใช้ Context ID อย่างสม่ำเสมอ**: เมื่อสร้าง context แล้ว ให้ใช้ ID ของมันอย่างสม่ำเสมอสำหรับคำขอที่เกี่ยวข้องทั้งหมดเพื่อรักษาความต่อเนื่อง

- **สร้างสรุป**: เมื่อ context มีขนาดใหญ่ ให้พิจารณาสร้างสรุปเพื่อจับข้อมูลสำคัญในขณะที่จัดการขนาดของ context

- **ใช้งานการควบคุมการเข้าถึง**: สำหรับระบบที่มีผู้ใช้หลายคน ให้ใช้งานการควบคุมการเข้าถึงที่เหมาะสมเพื่อรับประกันความเป็นส่วนตัวและความปลอดภัยของ context การสนทนา

- **จัดการข้อจำกัดของ Context**: ตระหนักถึงข้อจำกัดของขนาด context และนำนโยบายมาใช้สำหรับจัดการกับการสนทนาที่ยาวมาก

- **เก็บถาวรเมื่อเสร็จสิ้น**: เก็บถาวร context เมื่อการสนทนาเสร็จสิ้นเพื่อปล่อยทรัพยากรพร้อมทั้งเก็บรักษาประวัติการสนทนา

## ขั้นตอนถัดไป

- [Routing](../mcp-routing/README.md)

**Disclaimer**:  
Thi document haz ben translatid uzing AI translashun servis [Co-op Translator](https://github.com/Azure/co-op-translator). Whil wi striv for akurasi, pliz be awar that otomated translashuns may contain erors or inakurasis. Thi orijinal document in its nativ langwaj shud be konsiderd thi authoritativ sors. For kritikel informashun, profeshunal hyuman translashun iz rekomended. Wi ar not laibel for eni misandurstandings or misinterpretashuns arising from thi yuz of this translashun.