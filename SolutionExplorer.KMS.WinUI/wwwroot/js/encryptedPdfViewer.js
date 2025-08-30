window.encryptedPdfViewer = {
    loadPdf: async function (containerId, base64Data) {
        const container = document.getElementById(containerId);
        if (!container) return;

        // Decode Base64 → Uint8Array
        const raw = atob(base64Data);
        const rawLength = raw.length;
        const array = new Uint8Array(new ArrayBuffer(rawLength));
        for (let i = 0; i < rawLength; i++) {
            array[i] = raw.charCodeAt(i);
        }

        const loadingTask = pdfjsLib.getDocument({
            data: array,
            cMapUrl: '/pdfjs/web/cmaps/',
            cMapPacked: true,
            standardFontDataUrl: '/pdfjs/web/standard_fonts/'
        });

        const pdf = await loadingTask.promise;
        container.innerHTML = ''; // پاک کردن محتوای قبلی

        const containerWidth = container.clientWidth; // عرض باکس والد

        for (let pageNum = 1; pageNum <= pdf.numPages; pageNum++) {
            const page = await pdf.getPage(pageNum);

            // محاسبه scale برای پر کردن کل عرض
            const unscaledViewport = page.getViewport({ scale: 1 });
            const scale = containerWidth / unscaledViewport.width;
            const viewport = page.getViewport({ scale: scale });

            // هر صفحه → یک div مستقل
            const pageDiv = document.createElement('div');
            pageDiv.className = 'pdf-page';
            pageDiv.style.position = 'relative';
            pageDiv.style.marginBottom = '20px';
            pageDiv.style.width = viewport.width + 'px';
            pageDiv.style.height = viewport.height + 'px';

            // canvas
            const canvas = document.createElement('canvas');
            const context = canvas.getContext('2d');
            canvas.height = viewport.height;
            canvas.width = viewport.width;
            pageDiv.appendChild(canvas);

            // رندر صفحه
            await page.render({
                canvasContext: context,
                viewport: viewport
            }).promise;

            // لایه متن
            const textContent = await page.getTextContent();
            const textLayerDiv = document.createElement('div');
            textLayerDiv.className = 'textLayer';
            textLayerDiv.style.position = 'absolute';
            textLayerDiv.style.left = 0;
            textLayerDiv.style.top = 0;
            textLayerDiv.style.height = viewport.height + 'px';
            textLayerDiv.style.width = viewport.width + 'px';
            pageDiv.appendChild(textLayerDiv);

            pdfjsLib.renderTextLayer({
                textContent,
                container: textLayerDiv,
                viewport,
                textDivs: []
            });

            container.appendChild(pageDiv);
        }
    }
};