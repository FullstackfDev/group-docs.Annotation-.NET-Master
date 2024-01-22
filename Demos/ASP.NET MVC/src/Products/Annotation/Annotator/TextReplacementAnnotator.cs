﻿using GroupDocs.Annotation.Models;
using GroupDocs.Annotation.Models.AnnotationModels;
using GroupDocs.Annotation.Options;
using System;
using GroupDocs.Annotation.AspNetMvc.Products.Annotation.Annotator;
using GroupDocs.Annotation.AspNetMvc.Products.Annotation.Entity.Web;

namespace GroupDocs.Annotation.AspNetMvc.Products.Annotation.Annotator
{
    public class TextReplacementAnnotator : AbstractTextAnnotator
    {
        private ReplacementAnnotation replacementAnnotation;

        public TextReplacementAnnotator(AnnotationDataEntity annotationData, PageInfo pageInfo)
            : base(annotationData, pageInfo)
        {
            replacementAnnotation = new ReplacementAnnotation
            {
                Points = GetPoints(annotationData, pageInfo),
                TextToReplace = annotationData.text
            };
        }

        public override AnnotationBase AnnotateWord()
        {
            replacementAnnotation = InitAnnotationBase(replacementAnnotation) as ReplacementAnnotation;
            return replacementAnnotation;
        }

        public override AnnotationBase AnnotatePdf()
        {
            return AnnotateWord();
        }

        public override AnnotationBase AnnotateCells()
        {
            return AnnotateWord();
        }

        public override AnnotationBase AnnotateSlides()
        {
            return AnnotateWord();
        }

        public override AnnotationBase AnnotateImage()
        {
            throw new NotSupportedException(string.Format(Message, annotationData.type));
        }

        public override AnnotationBase AnnotateDiagram()
        {
            throw new NotSupportedException(string.Format(Message, annotationData.type));
        }

        protected override AnnotationType GetType()
        {
            return AnnotationType.TextReplacement;
        }
    }
}