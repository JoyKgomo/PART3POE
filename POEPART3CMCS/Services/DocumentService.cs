﻿using POEPART3CMCS.Models;
using System.Security.Claims;
using POEPART3CMCS.Services;

namespace POEPART3CMCS.Services

{
    public class DocumentService
    {
        ClaimContext claimContext;
        public DocumentService(ClaimContext claimContext)
        {
            claimContext = claimContext;
            claimContext.Database.EnsureCreated();
        }

        //add new document
        public int AddClaimDocument(Document claimDocument)
        {

            claimContext.Documents.Add(claimDocument);
            return claimDocument.Id;
        }

        public void DeleteClaimDocument(int claimDocumentId)
        {
            var claimDocument = claimContext.Documents.FirstOrDefault(x => x.Id == claimDocumentId);
            if (claimDocument != null)
            {
                claimContext.Documents.Remove(claimDocument);
                // claimsContext.SaveChanges();
            }
        }



        //get documents for a claim
        public List<Document> GetClaimDocuments(int claimId)
        {
            var claimDocuments = claimContext.Documents.Where(x => x.Id == claimId).ToList();
            return claimDocuments;
        }

    }

}

