

namespace MAPRes
{
    partial class WorkSpace
    {

        public void PerformAssociationRulesMining(WorkProgressEventHandler onEventFunction, TypeOfPreferrence typeOfPreferrence, float minSupportLevel, bool useVariantSupport)
        {
            AssociationRulesMining arm;
            string subjectBookmarked = SelectedSubject;
            foreach (string subject in this.SubjectNames)
            {

            SelectedSubject = subject;
                using (arm = new AssociationRulesMining(this, typeOfPreferrence, minSupportLevel, useVariantSupport))
                {
                    if (onEventFunction != null)
                        arm.AssociationRulesMiningProgress += new WorkProgressEventHandler(onEventFunction);
                    arm.RunAssociationRulesMining();
                    _isDirty = true;
                }
            }
            SelectedSubject = subjectBookmarked;

            project.AssociationAnalysisPerformed = true;
        }

        public void PerformPreferrenceEstimation(WorkProgressEventHandler onEventFunction)
        {
            PreferrenceEstimation pe;
            string subjectBookmarked = SelectedSubject;
            foreach (string subject in this.SubjectNames)
            {
                SelectedSubject = subject;
                using (pe = new PreferrenceEstimation(this))
                {
                    if (onEventFunction != null)
                        pe.PreferrenceEstimationProgress += new WorkProgressEventHandler(onEventFunction);
                    SubjectsHash[SelectedSubject].PreferredSitesDataTable = pe.DoEstimation();
                    _isDirty = true;
                }
            }
            SelectedSubject = subjectBookmarked;
            project.PreferrenceEstimationPerformed = true;
        }
    }
}